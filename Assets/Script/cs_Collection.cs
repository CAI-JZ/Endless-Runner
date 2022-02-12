using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Collection : MonoBehaviour
{
    protected float FadeSpeed = 0.03f;
   

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
