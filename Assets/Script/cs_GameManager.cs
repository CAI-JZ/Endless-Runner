using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GameManager : MonoBehaviour
{
    public static cs_GameManager Instance;

    GameObject Player;


    private void Awake()
    {
        Instance = this;
    }


    public int GameState(int State)
    {
        int GameState = 0;
        //BeforeStart 0;
        //StartGame 1;
        //GameOver 2;

        GameState = State;
        Debug.Log("game state:" + GameState);
        return GameState;
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
