using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   //-> Eager Loading
    public static GameManager Instance { get; private set; }
    private GameManager() { }
    
    public GameObject GUIManager;
    public GameObject Back1;
    public GameObject Back2;
    public GameObject Back3;
   
    public int GameStateIndex;

    GameObject Player;


    private void Awake()
    {
       
       Instance = this;

        //Define Player
        Player = GameObject.FindGameObjectWithTag("Player");
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
            Debug.Log("game state: GameStart");
            
        }
        else if (GameStateIndex == 2)
        {
            Debug.Log("game state: GameOver");
            Player.SendMessage("GameOver");
            GUIManager.SendMessage("GameEnd");

            Back1.SendMessage("GameEnd");
            Back2.SendMessage("GameEnd");
            Back3.SendMessage("GameEnd");
        }

        Debug.Log("game state:" + GameStateIndex);

    }

    public void PlayBtuClick()
    {
        SeedGenerator.Instance.ApplySeed();
        GUIManager.SendMessage("GameBegin");
        Player.SendMessage("StartGame");
        GameStateIndex = 1;
        Back1.SendMessage("GameStart");
        Back2.SendMessage("GameStart");
        Back3.SendMessage("GameStart");
    }

    public void Repaly()
    {
        SceneManager.LoadScene("2D");
    }

    void Start()
    {
        //Set Gamestate
        GameStateIndex = 0;

        //Set GamePool Object state
       
    }

    //Templete of Delegate
    public static int Num(int a)
    {
        int b = a;
        return b;
    }

    Number LN = new Number(Num);

}

