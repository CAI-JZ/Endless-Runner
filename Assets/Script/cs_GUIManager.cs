using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cs_GUIManager : MonoBehaviour
{
    //To Control the Show or Hide of UI in GAME
    
    [SerializeField]
    CanvasGroup Gameplay;
    [SerializeField]
    CanvasGroup MainUI;
    [SerializeField]
    CanvasGroup GameOver;
    [SerializeField]
    CanvasGroup HighScore;
    [SerializeField]
    CanvasGroup Seed;

    private float FadeSpeed = 0.08f;

    private void Awake()
    {
        if (!MainUI.gameObject.activeSelf)
        {
            MainUI.gameObject.SetActive(true);
        }

    }
    private void Start()
    {
        GameManager.Instance.whenGameStart += GameBegin;
        GameManager.Instance.whenGameOver += GameEnd;
    }

    public void GameBegin()
    {
        HideUI(MainUI);
        ShowUI(Gameplay);
    }

    public void GameEnd()
    {
        ShowUI(GameOver);
        HideUI(Gameplay);
    }

    public void ShowUISeed()
    {
        Seed.gameObject.SetActive(true);
        ShowUI(Seed);
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
        if (!C.gameObject.activeSelf)
        {
            C.gameObject.SetActive(true);
        }
        while (C.alpha < 1)
        {
            C.alpha += FadeSpeed;
            yield return new WaitForFixedUpdate();
        }
    }

    public void RestartGame()
    {
        HighScore.gameObject.SetActive(false);
        if (!MainUI.gameObject.activeSelf)
        {
            MainUI.gameObject.SetActive(true);
            ShowUI(MainUI);
        }
        GameManager.Instance.Repaly();
    }


}
