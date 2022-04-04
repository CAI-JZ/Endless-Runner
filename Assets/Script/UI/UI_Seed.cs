using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Seed : MonoBehaviour
{
    [SerializeField] Text ShowSeed;
    [SerializeField] InputField EnterSeed;
    [SerializeField] GameObject DefaultSelect;
    [SerializeField] GameObject ExitSelect;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DefaultSelect);
    }

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
            print("Loop time: " + (i + 1)  + "- result: "+ temp[i]);
        }
        #endif
        gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ExitSelect);
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
