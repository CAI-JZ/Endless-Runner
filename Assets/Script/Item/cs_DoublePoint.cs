using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_DoublePoint : cs_Collectable
{
    protected override void CollectEvent(Collider2D Player)
    {
        //Player change to doule point
        ScoreManager.Instance.DoublePoint();
        Player.transform.GetChild(1).gameObject.SetActive(true);
       
    }
}
