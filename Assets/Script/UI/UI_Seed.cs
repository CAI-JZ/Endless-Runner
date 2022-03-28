using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Seed : MonoBehaviour
{
    [SerializeField] Text ShowSeed;
    [SerializeField] InputField EnterSeed;

    private void Start()
    {
        ShowSeed.text = SeedGenerator.Instance.SeedToShow.ToString();
    }

    public void OnButtonRandomSeed()
    {
        SeedGenerator.Instance.GenerateRandomSeed();
        ShowSeed.text = SeedGenerator.Instance.SeedToShow.ToString();
    }

    public void OnButtonApplySeed()
    {
        SeedGenerator.Instance.ApplySeed();

        #if UNITY_EDITOR
        //Test Seed Random num
        int[] temp = new int[3];

        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = Random.Range(0, 100);
            print("��" + (i + 1) + "��ѭ����" + temp[i]);
        }
        #endif
        gameObject.SetActive(false);
    }

    public void OnButtonEntryYourSeed()
    {
        if (EnterSeed.text != null)
        { 
            string playerSeed = EnterSeed.text;
            SeedGenerator.Instance.UsePlayerSeed(playerSeed);
            ShowSeed.text = playerSeed;
        }
    }
}
