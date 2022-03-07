using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    [SerializeField]
    Text Score;
    [SerializeField]
    InputField InputField;
    [SerializeField]
    CanvasGroup GameOverScreen;
    [SerializeField]
    CanvasGroup HighScoreBoard;

    private void OnEnable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Awake()
    {
        ShowGameOverScreen();
    }

    void ShowGameOverScreen()
    {
        Score.text = ScoreManager.Instance.Score.ToString();
    }

    public void OnButtonSubmit()
    {
        if (!string.IsNullOrEmpty(InputField.text))
        {
            ScoreManager.Instance.UpdatePlayerName(InputField.text);
        }
        HideGameOver();
    }

    void HideGameOver()
    {
        gameObject.SetActive(false);
        ScoreManager.Instance.SaveByJson();
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
