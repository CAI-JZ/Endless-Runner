using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
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
        transform.position = new Vector3(0, PlayerPos.y +4.5f, PlayerPos.z - 10);
    }

}
