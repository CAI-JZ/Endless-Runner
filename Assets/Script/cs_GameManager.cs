using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cs_GameManager : MonoBehaviour
{
   //-> Eager Loading
    private static cs_GameManager instance;
    private cs_GameManager() { }
    //public static cs_GameManager Instance
    //{
    //    get 
    //    {
    //        // create logic to ceeate the instance
    //        if (instance == null)
    //        {
    //            GameObject go = new GameObject("cs_GameManager");
    //            go.AddComponent<cs_GameManager>();
    //        }
    //        return instance;
    //    }

    //}

    public static cs_GameManager Instance() { return instance;}

    public GameObject LightPrefab;
    public GameObject GUIManager;
    public GameObject Back1;
    public GameObject Back2;
    public GameObject Back3;
   
    public int Point {get; private set;}
    public int GameStateIndex;

    private List<GameObject> Collections = new List<GameObject>();
    GameObject Player;


    private void Awake()
    {
        instance = this;
        Point = 0;
        //Define Player
        Player = GameObject.FindGameObjectWithTag("Player");

        //Create CollectionPool
        int count = 10;
        for (int i = 0; i < count; i++)
        {
            GameObject Light = ObjectPool.Instance.GetObject(LightPrefab);
            Light.transform.position = new Vector3(0, 0, 50);
            Collections.Add(Light);
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestory"));
    }

    public void UpdatePoint(int point)
    {
        Point += point;
      
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
        if (Collections.Count > 0)
        {
            foreach (GameObject G in Collections)
            {
                ObjectPool.Instance.PushObject(G);
            }
        }

    }

    //Templete of Delegate
    public static int Num(int a)
    {
        int b = a;
        return b;
    }

    Number LN = new Number(Num);

}


