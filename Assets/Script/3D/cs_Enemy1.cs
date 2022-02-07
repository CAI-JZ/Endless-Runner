using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Enemy1 : MonoBehaviour
{
    public float MoveSpeed = 5;
    public Transform CurrentTrans;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("End");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentTrans.position += Vector3.up * MoveSpeed * Time.deltaTime;
        if (CurrentTrans.position.y >= 4 || CurrentTrans.position.y < 0)
        {
            MoveSpeed = -MoveSpeed;
        }
    }
}
