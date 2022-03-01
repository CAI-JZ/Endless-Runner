using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    // Singleton
    private static ObjectPool instance;
    private ObjectPool() {}
    //public static cs_ObjectPool Instance() { return instance; }
    

    //-> lazy loading
    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObjectPool();
            }
            return instance;
        }
    }
 

    private Dictionary<string, Queue<GameObject>> ObjectPools = new Dictionary<string, Queue<GameObject>>();
    private GameObject pool;
    
    public GameObject GetObject(GameObject prefab)
    {
        GameObject new0bject;
        if (!ObjectPools.ContainsKey(prefab.name) || ObjectPools[prefab.name].Count == 0)
        {
            new0bject = GameObject.Instantiate(prefab);
            PushObject(new0bject);
            if (pool == null)
            {
                pool = new GameObject("ObjectPool");
                pool.tag = "DontDestory";
            }
            GameObject childPool = GameObject.Find(prefab.name + "Pool");
            if (!childPool) 
            {
                childPool = new GameObject(prefab.name + "Pool");
                childPool.transform.SetParent(pool.transform);
            }
            new0bject.transform.SetParent(childPool.transform);
        }
        new0bject = ObjectPools[prefab.name].Dequeue();
        new0bject.SetActive(true);
        return new0bject;

    }

    public void PushObject(GameObject prefab)
    {
        string _name = prefab.name.Replace("(Clone)", string.Empty);
        if (!ObjectPools.ContainsKey(_name))
        {
            ObjectPools.Add(_name, new Queue<GameObject>());
        }
        ObjectPools[_name].Enqueue(prefab);
        prefab.SetActive(false);
    }
}
