using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Obstruct2D : cs_Item
{
    // set random obstruct location.
    void RandomObstruct()
    {
        int Pos = Random.Range(1,5);
        //print(Pos);
        float ScaleX1 = Random.Range(1f,1.5f);
        float ScaleX2 = Random.Range(0.6f, 1.3f);
        float Offset = Random.Range(-0.1f, 0.03f);
        switch (Pos)
        {
            case 1: //left
                transform.localPosition = new Vector3(-0.5f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(transform.localScale.x* ScaleX1, 0.05f, 1);
               
                break;

            case 2: //Center
                transform.localPosition = new Vector3(Offset*2f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(transform.localScale.x * ScaleX2, 0.05f, 1);
                break;

            case 3: //Center
                transform.localPosition = new Vector3(Offset * 6f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(transform.localScale.x * ScaleX2, 0.05f, 1);
                break;

            case 4: //Right
                transform.localPosition = new Vector3(0.5f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(transform.localScale.x * ScaleX1, 0.05f, 1);
                break;
        }
       
    }
 
    // Start is called before the first frame update
    void Start()
    {
        RandomObstruct();
    }

    // Touch obstruct -> GameOver
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            cs_GameManager.Instance().GameState(2);
        }
    }

    
}
