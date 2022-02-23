using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_PlayerSkillTrigger : MonoBehaviour
{

    private bool isInput;
    GameObject Target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            Target = collision.gameObject;
        }

    }

    void FightBack()
    {
        if (Target != null)
        {
            Target.GetComponent<Rigidbody2D>().gravityScale = 0;
            Target.GetComponent<SpriteRenderer>().flipY = true;
            Target.GetComponent<Rigidbody2D>().AddForce(transform.up * 0.4f, ForceMode2D.Impulse);
        }
        
    }

    private void Update()
    {
        isInput = Input.GetKeyDown(KeyCode.Mouse0);
        FightBack();
    }
}
