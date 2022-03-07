using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private ScoreManager() { }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        LoadHighScoreDatas();//?? Maybe Have other way��
    }

    public float Score => NewScore;
    public string playerName => PlayerName;
    public bool HasNewScore => NewScore > LoadHighScoreDatas().ScoreList[9].Score;

    const string PLAYER_DATA_FILENAME = "PlayerData.json";
    string PlayerName = " - ";
    float NewScore = 0;

    public void UpdateScore( float value)
    {
        NewScore += value;
    }

    public void UpdatePlayerName(string name)
    {
        PlayerName = name;
    }

    /* --------HighScore Board------------*/
    // A Class for ScoreData;
    [System.Serializable]
    public class PlayerScore
    {
        public string PlayerName;
        public float Score;

        public PlayerScore(string playerName, float score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }

    // A Class for Score List
    [System.Serializable] public class ScoreDatas
    {
        public List<PlayerScore> ScoreList = new List<PlayerScore>();
    }


    // Save Data to Json
    public void SaveByJson()
    {
        var PlayerScore = LoadHighScoreDatas();

        PlayerScore.ScoreList.Add(new PlayerScore(PlayerName, NewScore));
        PlayerScore.ScoreList.Sort((x, y) => y.Score.CompareTo(x.Score));

        SaveSystem.SaveData(PLAYER_DATA_FILENAME, PlayerScore);
    }

    // Load Data from Json
    public ScoreDatas LoadHighScoreDatas()
    {
        var scores = new ScoreDatas();

        if (SaveSystem.SaveFileExist(PLAYER_DATA_FILENAME))
        {
            scores = SaveSystem.LoadData<ScoreDatas>(PLAYER_DATA_FILENAME);
        }
        else
        {
            while (scores.ScoreList.Count < 10)
            {
                scores.ScoreList.Add(new PlayerScore(PlayerName, 0));    
            }
            SaveSystem.SaveData(PLAYER_DATA_FILENAME, scores);
        }
        return scores;
    }

    [UnityEditor.MenuItem("Developer/Delete Score Data Save File")]
    public static void DeleteScoreSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILENAME);
    }
}
