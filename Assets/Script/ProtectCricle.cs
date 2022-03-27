using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectCricle : MonoBehaviour
{
    [SerializeField]
    int value => PortectValue;

    private int PortectValue;

    private void OnEnable()
    {
        PortectValue = 3;
        print("[]got protect");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Sword" && PortectValue>0 )
        {
            PortectValue--;
            print(PortectValue);
            collision.GetComponent<Rigidbody2D>().gravityScale = -1;
            collision.GetComponent<SpriteRenderer>().flipY = true;
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * 3f, ForceMode2D.Impulse);
            if (PortectValue <= 0)
            {
                gameObject.SetActive(false);
            }
        }

    }

    public void AddPower()
    {
        PortectValue += 3;
    }
}
