using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Background : MonoBehaviour
{

    public GameObject Obstruck1;
    public GameObject Obstruck2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Transform>().position += new Vector3(0, 36, 0);
            Obstruck1.SendMessage("RandomObstruct");
            Obstruck2.SendMessage("RandomObstruct");
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
