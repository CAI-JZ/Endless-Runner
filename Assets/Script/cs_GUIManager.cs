using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class cs_GUIManager : MonoBehaviour
{
    //To Control the Show or Hide of UI in GAME
    
    [SerializeField] CanvasGroup Gameplay;
    [SerializeField] CanvasGroup MainUI;
    [SerializeField] CanvasGroup GameOver; 
    [SerializeField] CanvasGroup HighScore;
    [SerializeField] CanvasGroup Seed;

    [SerializeField] GameObject DefaultSelect;

    private float FadeSpeed = 0.08f;

    private void Awake()
    {
        if (!MainUI.gameObject.activeSelf)
        {
            MainMenuEnable();
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

    private void MainMenuEnable()
    {
        ShowUI(MainUI);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DefaultSelect);
    }

    public void ShowUISeed()
    {
        Seed.gameObject.SetActive(true);
        ShowUI(Seed);
    }

    public void RestartGame()
    {
        HideUI(HighScore);
        GameManager.Instance.Repaly();
        if (!MainUI.gameObject.activeSelf)
        {
            MainMenuEnable();
        }
    }

    public void OnbtnStartGame()
    {
        SeedGenerator.Instance.ApplySeed();
        GameManager.Instance.GameState(1);
    }

    public void OnbtnExit()
    {
#if UNITY_EDITOR
        ScoreManager.Instance.SaveByJson();
        UnityEditor.EditorApplication.isPlaying = false;
#else
        ScoreManager.Instance.SaveByJson();   
        Application.Quit();
#endif
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
            yield return new WaitForSecondsRealtime(0);
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
            yield return new WaitForSecondsRealtime(0);
        }
    }


}
