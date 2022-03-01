using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text HighScore;
    [SerializeField]
    private GameObject InputField;

    public string UserName;
   

    private void Awake()
    {
        ShowHighScore(cs_GameManager.Instance().Point);
        
    }

    public void StoreName()
    {
        UserName = InputField.GetComponent<Text>().text;
    }


    void ShowHighScore(float CurrentScore)
    {
        float highScore = PlayerPrefs.GetFloat("Score", 0);    

        if (CurrentScore > highScore)
        {
            highScore = CurrentScore;
        }
        PlayerPrefs.SetFloat("Score", highScore);
        Score.text = string.Format("Your Score: {0}", CurrentScore);
        HighScore.text = string.Format("High Score: {0}", highScore);
    }

}
