using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_ProtectItem : cs_Collectable
{
    protected override void CollectEvent(Collider2D Player)
    {
        base.CollectEvent(Player);
        Player.SendMessage("GetPortect");
    }
}
