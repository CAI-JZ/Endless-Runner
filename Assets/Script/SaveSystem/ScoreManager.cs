using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private ScoreManager() { }

    float Parameter = 1;
    private float KeepTime = 5;
    private GameObject Player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }   

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public float Score => (float)Math.Truncate( NewScore);
    public string playerName => PlayerName;
    public bool HasNewScore => NewScore > LoadHighScoreDatas().ScoreList[9].Score;

    const string PLAYER_DATA_FILENAME = "PlayerData.json";
    string PlayerName = " - ";
    float NewScore = 0;


    private void Start()
    {
        LoadHighScoreDatas();//?? Maybe Have other way£»
    }

    private void FixedUpdate()
    {
        ScorePreSecend();
    }

    void ScorePreSecend()
    {
        float value = 0; 
        if (GameManager.Instance.GameStateIndex == 1)
        { 
            value += (Time.deltaTime*2);
            UpdateScore(value);
        }
    }

    public void UpdateScore( float value)
    {
        NewScore +=value * Parameter;
    }

    public void DoublePoint()
    {
        Parameter = 2;    
        KeepTime += 2;
        StartCoroutine(Cold());
        
    }

    public IEnumerator Cold()
    {
        while (KeepTime > 0)
        {
            KeepTime = KeepTime - Time.deltaTime;
            //print(KeepTime);
            yield return new WaitForFixedUpdate();
        }
        Parameter = 1;
        Player.transform.GetChild(1).gameObject.SetActive(false);
        //print("²»ÊÇË«±¶ÁË");
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

        PlayerScore.ScoreList.Add(new PlayerScore(PlayerName, Score));
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
