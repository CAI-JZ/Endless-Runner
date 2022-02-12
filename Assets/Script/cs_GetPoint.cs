using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GetPoint : cs_Collection
{
    cs_GameManager instance;
    SpriteRenderer sprite;

    private int Value = 10;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cs_GameManager.Instance.UpdatePoint(Value);
            //this.get
            StartCoroutine(UnActive(sprite));
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
