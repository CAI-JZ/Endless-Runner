using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Camera : MonoBehaviour
{
    private GameObject Player;
    private Vector3 PlayerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = Player.GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3 (PlayerPos.x+11, 3f, PlayerPos.z+4);
    }
}