using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Background : MonoBehaviour
{

    public GameObject Obstruck1;
    public GameObject Obstruck2;
    public GameObject LightPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Transform>().position += new Vector3(0, 36, 0);
            Obstruck1.SendMessage("RandomObstruct");
            Obstruck2.SendMessage("RandomObstruct");
            cs_ObjectPool.Instance.PushObject(LightPrefab);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject Light = cs_ObjectPool.Instance.GetObject(LightPrefab);
        Light.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
