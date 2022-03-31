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

    public string SeedToShow;
    private int SeedCode;

    public void GenerateRandomSeed()
    {
        int tempSeed = Random.Range(0, 999999);
        SeedToShow = tempSeed.ToString();
        SeedCode = tempSeed.ToString().GetHashCode();
        #if UNITY_EDITOR
        Debug.Log("Seed to show£º" + SeedToShow + "; Seed to Apply£º " + SeedCode);
        #endif
    }

    public void ApplySeed()
    {
        Random.InitState(SeedCode);
        #if UNITY_EDITOR
        Debug.Log("Successfully apply seed£º" + SeedToShow + " : " + SeedCode);
        #endif
    }

    public void UsePlayerSeed(string PlayerSeed)
    {
        SeedCode = PlayerSeed.GetHashCode();
        SeedToShow = PlayerSeed;
        #if UNITY_EDITOR
        Debug.Log("Successfully input Seed£º" + PlayerSeed + " - " + SeedCode);
        #endif
    }

}
