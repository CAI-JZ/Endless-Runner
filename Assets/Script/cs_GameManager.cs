using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GameManager : MonoBehaviour
{
    public static cs_GameManager Instance;

    GameObject Player;

    public  int Point = 0;
    private int GameStateIndex;
    public int FrontSize = 10;


    private void Awake()
    {
        Instance = this;
    }

    public int UpdatePoint(int point)
    {
        Point += point;
        return Point;
    }

    

    //BeforeStart 0;
    //StartGame 1;
    //GameOver 2;

    public void GameState(int GameState)
    {
        GameStateIndex = GameState;
        if (GameStateIndex == 1)
        {
            Debug.Log("game state: GameStart");
            Player.SendMessage("StartGame");
        }
        else if (GameStateIndex == 2)
        {
            Debug.Log("game state: GameOver");
            Player.SendMessage("GameOver");
        }

        Debug.Log("game state:" + GameStateIndex);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameStateIndex = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && GameStateIndex == 0)
        {
            GameState(1);
        }
    }
}
