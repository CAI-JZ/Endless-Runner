using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectCricle : MonoBehaviour
{
    [SerializeField]
    public static bool IsProtect;
    [SerializeField]
    private int PortectValue;

    private void OnEnable()
    {
        PortectValue = 3;
        IsProtect = true;
        print("[]got protect");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            PortectValue--;
            float v = collision.gameObject.GetComponent<EnemyBase>()._value;
            ObjectPool.Instance.PushObject(collision.gameObject);
            ScoreManager.Instance().UpdateScore(v);
        }
        if (collision.tag == "Sword" )
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = -1;
            collision.GetComponent<SpriteRenderer>().flipY = true;
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * 3f, ForceMode2D.Impulse);
            PortectValue--;
        }
        
        if (PortectValue <= 0)
        {
            IsProtect = false;
            gameObject.SetActive(false);
        }
    }

    public void AddPower()
    {
        PortectValue += 3;
    }
}
