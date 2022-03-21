using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEncrypt : MonoBehaviour
{
    string Test = "Hello";
    string TestFileName = "TestHello.json";
    private static string Key = "kljsdkkdlo4454GG";


    private void Start()
    {
        var a = AESEncrypt.Encrypt(Key, Test);
        Debug.Log("Final Encrypt content: " + a);
        var b = AESEncrypt.Decrypt(Key, a);
        Debug.Log("Final Dncrypt content: " + b);


    }

}
