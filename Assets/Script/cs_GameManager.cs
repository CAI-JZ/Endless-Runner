using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GameManager : MonoBehaviour
{
    public static cs_GameManager Instance;

    GameObject Player;

    private int Point;


    private void Awake()
    {
        Instance = this;
    }

    public int UpdatePoint(int point)
    {
        this.Point += point;
        return Point;
    }


    public void GameState(int GameState)
    {
        
        //BeforeStart 0;
        //StartGame 1;
        //GameOver 2;
        if (GameState == 1)
        {
            Debug.Log("game state: GameStart");
            Player.SendMessage("StartGame");
        }
        else if (GameState == 2)
        {
            Debug.Log("game state: GameOver");
            Player.SendMessage("GameOver");
        }

        Debug.Log("game state:" + GameState);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
