using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GetPoint : MonoBehaviour
{
    cs_GameManager instance;

    private int Value = 10;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            cs_GameManager.Instance.UpdatePoint(Value);
            //this.get
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
