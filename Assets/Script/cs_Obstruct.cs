using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Obstruct : MonoBehaviour
{
    cs_GameManager instance;

    void RandomObstruct()
    {
        int Type = Random.Range(0,4);
        print(Type);
        float Offset = Random.Range(-0.1f,0.3f);
        print(Offset);
        switch (Type)
        {
            case 1: //need jump
                Debug.Log("1 Jump");
                transform.localPosition = new Vector3(transform.localPosition.x + Offset, -1, 0);
                break;

            case 2: //need roll
                Debug.Log("2 Roll");
                transform.localPosition = new Vector3(transform.localPosition.x + Offset, 8f, 0);
                break;

            case 3: //Just Pass
                Debug.Log("3 Can Pass");
                transform.localPosition = new Vector3(transform.localPosition.x + Offset, 11, 0);
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
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
