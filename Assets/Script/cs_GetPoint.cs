using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_GetPoint : cs_Collection
{
    SpriteRenderer sprite;

    private int Value = 10;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cs_GameManager.Instance.UpdatePoint(Value);
            //this.get
            StartCoroutine(UnActive(sprite));
        }
    }

    private void OnEnable()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
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
