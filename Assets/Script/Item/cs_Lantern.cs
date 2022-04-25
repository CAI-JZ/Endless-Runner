using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Lantern : cs_Collectable
{
    //new SpriteRenderer sprite;
    private int Value = 10;

    protected override void CollectEvent(Collider2D Player)
    {
        //cs_GameManager.Instance().UpdatePoint(Value);
        ScoreManager.Instance().UpdateScore(Value);
    }
}
