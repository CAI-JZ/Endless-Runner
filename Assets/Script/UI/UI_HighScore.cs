using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_HighScore : MonoBehaviour
{
    [SerializeField] Text CurrentPlsyerScore;
    [SerializeField] Text CurrentPlayerName;
    [SerializeField] Canvas HighScoreScreenCanvas;
    [SerializeField] Transform HighScoreBoardContainer;
    [SerializeField] GameObject DefaultSelect;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DefaultSelect);
    }

    private void Start()
    {
        ShowHighSocre();
    }

    void ShowHighSocre()
    {
        HighScoreScreenCanvas.enabled = true;
        CurrentPlsyerScore.text = ScoreManager.Instance().Score.ToString();
        CurrentPlayerName.text = ScoreManager.Instance().playerName.ToString();
        UpdateHighScoreBoard();
    }

    void UpdateHighScoreBoard()
    {
        var ScoreList = ScoreManager.Instance().LoadHighScoreDatas().ScoreList;
        for (int i = 0; i < HighScoreBoardContainer.childCount; i++)
        {
            var child = HighScoreBoardContainer.GetChild(i);
            child.Find("Rank").GetComponent<Text>().text = (i + 1).ToString();
            child.Find("PlayerName").GetComponent<Text>().text = ScoreList[i].PlayerName.ToString();
            child.Find("PlayerScore").GetComponent<Text>().text = ScoreList[i].Score.ToString();
        }
    }
}
