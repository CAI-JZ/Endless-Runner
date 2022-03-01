using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate int Number(int n);

public class cs_Background : MonoBehaviour
{

    public GameObject Obstruck1;
    public GameObject Obstruck2;
    public GameObject LightPrefab;
    private List<GameObject> RandomObjects = new List<GameObject>();

    //private void Awake()
    //{
    //    NewLight(1);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Transform>().position += new Vector3(0, 36, 0);
            Obstruck1.SendMessage("RandomObstruct");
            Obstruck2.SendMessage("RandomObstruct");
            CheckUnuseObject();
            int RandomNum = Random.Range(1, 3);
            NewLight(RandomNum);
        }
    }

    void NewLight(int Num)
    {     
        for (int i = 0; i < Num; i++)
        {
            float Offset = Random.Range(-2f, 2f);
            GameObject Light = ObjectPool.Instance.GetObject(LightPrefab);
            Light.transform.position = transform.position + new Vector3(Offset, Offset*1.5f, 0);
            RandomObjects.Add(Light);
        }       
    }

    void CheckUnuseObject()
    {
        if (RandomObjects.Count > 0) 
        {
            foreach (GameObject G in RandomObjects)
            {
                if (G.activeSelf)
                {
                    ObjectPool.Instance.PushObject(G);    
                }                
            }
            RandomObjects.Clear();
        }
    }

    public void GameStart()
    {
        NewLight(1);
    }

    public void GameEnd()
    {
        //throw new System.NotImplementedException();
        CheckUnuseObject();
    }
}
