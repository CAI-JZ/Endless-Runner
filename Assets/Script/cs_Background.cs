using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Background : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            GetComponent<Transform>().position += new Vector3(0, 36, 0);
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
