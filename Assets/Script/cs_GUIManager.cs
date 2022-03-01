using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cs_GUIManager : MonoBehaviour
{
    //To Control the Show or Hide of UI in GAME
    
    [SerializeField]
    CanvasGroup Score;
    [SerializeField]
    CanvasGroup MainUI;
    [SerializeField]
    CanvasGroup GameOver;

    private float FadeSpeed = 0.05f;

    private void Awake()
    {
        if (!MainUI.gameObject.activeSelf)
        {
            MainUI.gameObject.SetActive(true);
        }

    }

    public void GameBegin()
    {
        HideUI(MainUI);
        ShowUI(Score);
    }

    public void GameEnd()
    {
        GameOver.gameObject.SetActive(true);
    }

    private void ShowUI(CanvasGroup CG)
    {
        StartCoroutine(Show(CG));
    }

    protected void HideUI(CanvasGroup CG)
    {
        StartCoroutine(Hide(CG));
        
    }

    private IEnumerator Hide(CanvasGroup C)
    {
        while (C.alpha > 0)
        {
            C.alpha -= FadeSpeed;
            yield return new WaitForFixedUpdate();
        }
        C.gameObject.SetActive(false);
    }

    private IEnumerator Show(CanvasGroup C)
    {
        while (C.alpha < 1)
        {
            C.alpha += FadeSpeed;
            yield return new WaitForFixedUpdate();
        }
    }

    public void RestartGame()
    {
               GameOver.gameObject.SetActive(false);
        if (!MainUI.gameObject.activeSelf)
        {
            MainUI.gameObject.SetActive(true);
            MainUI.alpha = 1;
        }
        Score.alpha = 0;
        
    }


}
