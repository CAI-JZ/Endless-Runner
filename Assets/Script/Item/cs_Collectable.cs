using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Collectable : cs_Item
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.GameStateIndex == 1)
        {
            CollectEvent(collision);
            base.OnTriggerEnter2D(collision);
        }
    }

    protected virtual void CollectEvent(Collider2D Player)
    {

    }

}
