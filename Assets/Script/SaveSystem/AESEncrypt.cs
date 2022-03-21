
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class AESEncrypt
{

    public static string Encrypt(string key, string content)
    {
        byte[] _key = Encoding.UTF8.GetBytes(key);
        byte[] _content = Encoding.UTF8.GetBytes(content);
        
        var aes = new RijndaelManaged();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = _key;

        ICryptoTransform cTransform = aes.CreateEncryptor(); 
        byte[] cryptData = cTransform.TransformFinalBlock(_content, 0, _content.Length);
        string CryptString = Convert.ToBase64String(cryptData);

#if UNITY_EDITOR
        Debug.Log("Encrypt: string content:  " + Encoding.UTF8.GetString(_content));
        Debug.Log("Encrypt: byte content:   " + BitConverter.ToString(_content));
        Debug.Log("Encrypt: byte cryptData:   " +BitConverter.ToString(cryptData));
        //Debug.Log("Encrypt: string cryptData:   " + Encoding.UTF8.GetString(cryptData));
#endif

        return CryptString;
    }

    public static string Decrypt(string key, string EnContent)
    {
        byte[] _key = Encoding.UTF8.GetBytes(key);
        byte[] _content = Convert.FromBase64String(EnContent);

        var aes = new RijndaelManaged();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = _key;

        ICryptoTransform cTransform = aes.CreateDecryptor();
        byte[] DecryptContent = cTransform.TransformFinalBlock(_content, 0, _content.Length);

        string DecryptString = Encoding.UTF8.GetString(DecryptContent);

#if UNITY_EDITOR
        Debug.Log("Decrypt: byte content:   " + Convert.ToBase64String(_content));
        Debug.Log("Decrypt: byte content:   " + BitConverter.ToString(_content));
        Debug.Log("byte DecryptContent:   " + BitConverter.ToString(DecryptContent));
#endif

        return DecryptString;
    }

}
