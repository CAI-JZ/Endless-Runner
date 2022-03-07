using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_BulletItem : cs_Collectable
{
  
    protected override void CollectEvent(Collider2D Player)
    {
        base.CollectEvent(Player);
        Player.SendMessage("GetBullet");    
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        m_rigidbody.gravityScale = 0;
    }
}
