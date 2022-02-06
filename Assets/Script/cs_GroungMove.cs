using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GroungMove : MonoBehaviour
{

    public Transform CurrentTrans;
    private Vector3 NewPos;


    private void RandomSetting()
    {
        //float PosY = Random.Range(0, 3);
        float PosZ = Random.Range(0, 0);
        NewPos = CurrentTrans.position + new Vector3(0, 0, 60 + PosZ);
        GetComponent<Transform>().position = NewPos;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RandomSetting();
        }
    }

    void Start()
    {

    }
}
