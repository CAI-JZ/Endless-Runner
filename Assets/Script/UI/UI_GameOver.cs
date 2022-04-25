using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_GameOver : MonoBehaviour
{
    [SerializeField] Text Score;
    [SerializeField] InputField InputField;
    [SerializeField] CanvasGroup GameOverScreen;
    [SerializeField] CanvasGroup HighScoreBoard;
    [SerializeField] GameObject DefaultSelect;

    private void OnEnable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


        ShowGameOverScreen();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DefaultSelect);
    }

    void ShowGameOverScreen()
    {
        Score.text = ScoreManager.Instance().Score.ToString();
    }

    public void OnButtonSubmit()
    {
        if (!string.IsNullOrEmpty(InputField.text))
        {
            ScoreManager.Instance().UpdatePlayerName(InputField.text);
        }
        HideGameOver();
    }

    void HideGameOver()
    {
        gameObject.SetActive(false);
        ScoreManager.Instance().SaveByJson();
        HighScoreBoard.gameObject.SetActive(true);

    }



    /*          Use PlayerPrefs            */
    //void ShowHighScore(float CurrentScore)
    //{
    //    float highScore = PlayerPrefs.GetFloat("Score", 0);    

    //    if (CurrentScore > highScore)
    //    {
    //        highScore = CurrentScore;
    //    }
    //    PlayerPrefs.SetFloat("Score", highScore);
    //    Score.text = string.Format("Your Score: {0}", CurrentScore);
    //    HighScore.text = string.Format("High Score: {0}", highScore);
    //}

}
