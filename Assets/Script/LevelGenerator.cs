using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate int Number(int n);

public class LevelGenerator : MonoBehaviour
{

    public GameObject Obstruck1;
    public GameObject Obstruck2;
    [SerializeField]
    private GameObject LightPrefab;
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private GameObject EnergyPrefab;
    [SerializeField]
    private GameObject DoublePoint;

    private List<GameObject> RandomObjects = new List<GameObject>();
    private List<GameObject> PoolObjects = new List<GameObject>();

    private void Awake()
    {
        PrepareObjects();
    }

    private void Start()
    {
        if (PoolObjects.Count > 0)
        { 
            foreach(GameObject pg in PoolObjects)
            {
                ObjectPool.Instance.PushObject(pg);
            }
        }
    }

    void PrepareObjects()
    {
        //Create CollectionPool
        int count = 2;
        for (int i = 0; i < count; i++)
        {
            SpawnObject(LightPrefab);
            SpawnObject(EnergyPrefab);
            SpawnObject(EnemyPrefab);
            SpawnObject(DoublePoint);
        }
    }

    void SpawnObject(GameObject prefab)
    {
        GameObject obj = ObjectPool.Instance.GetObject(prefab);
        obj.transform.position = new Vector3(0, 0, 50);
        PoolObjects.Add(obj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position += new Vector3(0, 36, 0);
            //Cancel the UnuseOjbect;
            CheckUnuseObject();
            // Generate new ojbect
            GenerateLevel();
        }
    }

    public void GameStart()
    {
        GenerateLevel();
    }

    public void GameEnd()
    {
        //throw new System.NotImplementedException();
        CheckUnuseObject();
    }

    void GenerateLevel()
    {
        //random obstacles
        Obstruck1.SendMessage("RandomObstruct");
        Obstruck2.SendMessage("RandomObstruct");

        //random collectable
        int count = Random.Range(1, 3);
        for (int i = 0; i < count; i++)
        {
            int type = Random.Range(0, 4);
            switch (type)
            {
                case 0:
                    RandomGenerator(LightPrefab, 0.3f);
                    break;
                case 1:
                    // generate light
                    RandomGenerator(LightPrefab, 1.5f);
                    break;
                case 2:
                    // generate energy
                    RandomGenerator(EnergyPrefab, 0.8f);
                    break;
                case 3:
                    //generate new item
                    RandomGenerator(DoublePoint, 1.2f);
                    break;
            }
        }
        //random enemy
        RandomGenerator(EnemyPrefab, 0f);
    }

    // a certain obj ; a certain location
    void RandomGenerator(GameObject objPrefab,  float parameter)
    {
            float Offset = Random.Range(-2f, 2f);
            GameObject obj = ObjectPool.Instance.GetObject(objPrefab);
            obj.transform.position = transform.position + new Vector3(Offset * parameter, Offset * parameter, 0);
            RandomObjects.Add(obj);
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

}
