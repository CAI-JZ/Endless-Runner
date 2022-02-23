using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Lantern : cs_Item
{
    //new SpriteRenderer sprite;
    private int Value = 10;

    //protected override void Awake()
    //{
    //    sprite = GetComponent<SpriteRenderer>();
    //}
 
    //protected override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    base.OnTriggerEnter2D(collision);
    //}

    protected override void TriggerPlayerEvent()
    {
        base.TriggerPlayerEvent();
        if (cs_GameManager.Instance.GameStateIndex == 1)
        {
            cs_GameManager.Instance.UpdatePoint(Value);
            //StartCoroutine(UnActive(sprite));
        }
    }



}
