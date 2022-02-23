using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GameManager : MonoBehaviour
{
    public static cs_GameManager Instance;

    public GameObject LightPrefab;
    public GameObject UIScore;
    public GameObject UIMain;
    public int Point = 0;
    public int GameStateIndex;

    private List<GameObject> Collections = new List<GameObject>();
    GameObject Player;


    private void Awake()
    {
        Instance = this;

        //Define Player
        Player = GameObject.FindGameObjectWithTag("Player");

        //Create CollectionPool
        int count = 10;
        for (int i = 0; i < count; i++)
        {
            GameObject Light = cs_ObjectPool.Instance.GetObject(LightPrefab);
            Light.transform.position = new Vector3(0, 0, 50);
            Collections.Add(Light);
        }
    }

    public int UpdatePoint(int point)
    {
        Point += point;
        return Point;
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
            Player.SendMessage("StartGame");
        }
        else if (GameStateIndex == 2)
        {
            Debug.Log("game state: GameOver");
            Player.SendMessage("GameOver");
        }

        Debug.Log("game state:" + GameStateIndex);

    }

    public void PlayBtuClick()
    {
        UIMain.GetComponent<cs_GUIManager>().HideUI();
        UIScore.GetComponent<cs_GUIManager>().ShowUI();
        GameState(1);
    }

    void Start()
    {
        //Set Gamestate
        GameStateIndex = 0;

        //Set GamePool Object state
        if (Collections.Count > 0)
        {
            foreach (GameObject G in Collections)
            {
                cs_ObjectPool.Instance.PushObject(G);
            }
        }

    }
}


