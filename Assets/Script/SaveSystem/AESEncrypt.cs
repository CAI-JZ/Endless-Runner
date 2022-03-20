
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

        //string HexCryptString = Hex_2To16(cryptData);
        //byte[] HexCryptData = Encoding.UTF8.GetBytes(HexCryptString);
        string CryptString = Convert.ToBase64String(cryptData, 0, cryptData.Length);
        
        return CryptString;
    }

    public static string Decrypt(string key, string EnContent)
    {
        byte[] _key = Encoding.UTF8.GetBytes(key);
        byte[] _content = Convert.FromBase64String(EnContent);
        //byte[] _key = Convert.FromBase64String(key);

        var aes = new RijndaelManaged();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = _key;

        ICryptoTransform cTransform = aes.CreateEncryptor();
        byte[] DecryptContent = cTransform.TransformFinalBlock(_content, 0, _content.Length);
  
        //string DecryptHexString = Encoding.UTF8.GetString(DecryptHexData);
        //byte[] DecryptData = Hex_16To2(DecryptHexString);
        string DecryptString = Encoding.UTF8.GetString(DecryptContent);

        return DecryptString;
    }

    private static byte[] Hex_16To2(string hexString)
    {
        if (hexString.Length < 1)
        {
            return null;
        }
        byte[] hexByte = new byte[hexString.Length / 2];
        int j = 0;
        for (int i = 0; i < hexString.Length; i+=2 )
        {
            hexByte[j] = Convert.ToByte(hexString.Substring(i, i + 2), 16);
            j++;
        }
        return hexByte;
    }

    private static string Hex_2To16(byte[] cryptData)
    {
        string hexString = string.Empty;
        int length = 65535;

        if (cryptData != null)
        {
            StringBuilder strB = new StringBuilder();

            if (cryptData.Length < length)
            {
                length = cryptData.Length;
            }

            for (int i = 0; i < length; i++)
            {
                strB.Append(cryptData[i].ToString("X2"));
            }
            hexString = strB.ToString();
        }
        return hexString;
    }
}
