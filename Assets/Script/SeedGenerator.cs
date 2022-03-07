using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    public static SeedGenerator Instance { get;  private set; }
    private SeedGenerator() { }

    private void Awake()
    {
        Instance = this;
        GenerateRandomSeed();
    }

    public int CurrentSeed;
    private int SeedCode;

    public void GenerateRandomSeed()
    {
        int tempSeed = Random.Range(0, 999999);
        CurrentSeed = tempSeed;
        SeedCode = tempSeed.ToString().GetHashCode();
        #if UNITY_EDITOR
        Debug.Log("չʾSeed��" + CurrentSeed + "; ʵ��Ӧ�õ�Seed�� " + SeedCode);
        #endif
    }

    public void ApplySeed()
    {
        Random.InitState(SeedCode);
        #if UNITY_EDITOR
        Debug.Log("�ɹ�Ӧ��Seed��" + CurrentSeed + " : " + SeedCode);
        #endif
    }

    public void UsePlayerSeed(string PlayerSeed)
    {
        SeedCode = PlayerSeed.GetHashCode();
        #if UNITY_EDITOR
        Debug.Log("�ɹ�������ҵ�Seed��" + PlayerSeed + " - " + SeedCode);
        #endif
    }

}
