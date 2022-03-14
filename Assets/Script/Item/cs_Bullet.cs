using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Bullet : cs_Item
{
    public float Speed = 3;
    private float GravityScale = 0.3f;
    public float time;
    private float Timeuse;

    public void SetSpeed(Vector2 direction)
    {
        m_rigidbody.velocity = direction * Speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IHit hit = collision.GetComponent<IHit>();
        if (hit != null)
        {
            if (hit.Hit())
            {
                base.OnTriggerEnter2D(collision);
            }          
        }
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        sprite.flipY = false;
        m_rigidbody.gravityScale = 0;
        Timeuse = time;
    }

    private void Update()
    {
        Timeuse -= Time.deltaTime;
        if (Timeuse <= 0)
        {
            ObjectPool.Instance.PushObject(gameObject);
        }
    }

}
