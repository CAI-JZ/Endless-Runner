using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cs_Item : MonoBehaviour
{
    protected float FadeSpeed = 0.08f;
    protected SpriteRenderer sprite;
    protected Rigidbody2D m_rigidbody;

    protected virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    protected IEnumerator UnActive(SpriteRenderer Sprite)
    {
        while (Sprite.color.a > 0)
        {
            Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Sprite.color.a - FadeSpeed);
            yield return new WaitForFixedUpdate();
        }
        //Destory Object
        cs_ObjectPool.Instance.PushObject(gameObject);
    }

    //Reset color.alpha = 1;
    protected virtual void OnEnable()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            TriggerPlayerEvent();
            StartCoroutine(UnActive(sprite));
        }
        if(collision.tag == "Enemy")
        {
            TriggerEnemyEvent();
            StartCoroutine(UnActive(sprite));
        } 
       
    }

    protected virtual void TriggerPlayerEvent()
    { 
    
    }

    protected virtual void TriggerEnemyEvent()
    {

    }


}
