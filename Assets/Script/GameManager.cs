using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   //-> Eager Loading
    public static GameManager Instance { get; private set; }
    private GameManager() { }
    
    private int GameStateIndex;
    public int _state => GameStateIndex;

    public event Action whenGameStart;
    public event Action whenGameOver;

    private void Awake()
    {
       
       Instance = this;

        
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestory"));
    }

    //GAMESTATE info
    //BeforeStart - 0;
    //StartGame   - 1;
    //GameOver    - 2;
    public void GameState(int GameState)
    {
        GameStateIndex = GameState;
        if (GameStateIndex == 1)
        {
            whenGameStart?.Invoke();
        }
        else if (GameStateIndex == 2)
        {
            whenGameOver?.Invoke();
            Time.timeScale = 0;
        }
        #if UNITY_EDITOR
        Debug.Log("game state:" + GameStateIndex);
        #endif
    }

    public void Repaly()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    void Start()
    {
        GameStateIndex = 0;
    }

}


