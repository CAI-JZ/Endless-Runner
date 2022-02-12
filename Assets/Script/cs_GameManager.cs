using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GameManager : MonoBehaviour
{
    public static cs_GameManager Instance;
    public GameObject LightPrefab;

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

        int count = 5;
        for (int i = 0; i< count; i++)
        {
            GameObject Light = cs_ObjectPool.Instance.GetObject(LightPrefab);
            Light.transform.position = new Vector3(0, 0, 50);
            Light.SetActive(false);
        }
       

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
