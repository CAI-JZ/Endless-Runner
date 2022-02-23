using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Bullet : cs_Item
{
    public float Speed = 3;
    private float GravityScale = 0.3f;
    
    //private Rigidbody2D Rigid;

    //new private void Awake()
    //{
    //    Rigid = GetComponent<Rigidbody2D>();
    //}

    public void SetSpeed(Vector2 direction)
    {
        m_rigidbody.velocity = direction * Speed;
    
    }

    protected override void TriggerEnemyEvent()
    {
        base.TriggerEnemyEvent();
        //else if (collision.tag == "Enemy")
        //{
        //    collision.SendMessage("Die");
        //    cs_ObjectPool.Instance.PushObject(gameObject);
        //}
    }

    protected override void TriggerPlayerEvent()
    {
        base.TriggerPlayerEvent();
        m_rigidbody.gravityScale = 0;
        cs_GameManager.Instance.GameState(2);
         
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        m_rigidbody.gravityScale = GravityScale;
    }

}
