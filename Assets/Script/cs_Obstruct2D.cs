using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Obstruct2D : MonoBehaviour
{
    cs_GameManager instance;
    

    // set random obstruct location.
    void RandomObstruct()
    {
        int Pos = Random.Range(1,5);
        print(Pos);
        float ScaleX1 = Random.Range(0.75f,1.5f);
        float ScaleX2 = Random.Range(0.45f, 0.7f);
        float Offset = Random.Range(-0.1f, 0.03f);
        switch (Pos)
        {
            case 1: //left
                transform.localPosition = new Vector3(-0.5f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(ScaleX1, 0.05f, 1);
               
                break;

            case 2: //Center
                transform.localPosition = new Vector3(Offset*2f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(ScaleX2, 0.05f, 1);
                break;

            case 3: //Center
                transform.localPosition = new Vector3(Offset * 5f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(ScaleX2, 0.05f, 1);
                break;

            case 4: //Right
                transform.localPosition = new Vector3(0.5f, transform.localPosition.y + Offset, transform.localPosition.z);
                transform.localScale = new Vector3(ScaleX1, 0.05f, 1);
                break;
        }
       
    }

    // Touch obstruct -> GameOver
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            cs_GameManager.Instance.GameState(2);
        }

    }
     


    // Start is called before the first frame update
    void Start()
    {
        RandomObstruct();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}