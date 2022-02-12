using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_ObjectPool
{
    private static cs_ObjectPool instance;
    private Dictionary<string, Queue<GameObject>> ObjectPool = new Dictionary<string, Queue<GameObject>>();
    private GameObject pool;

    public static cs_ObjectPool Instance {
        get {
            if (instance == null)
            {
                instance = new cs_ObjectPool();
            }
            return instance;
        }
    }

    public GameObject GetObject(GameObject prefab)
    { 
        GameObject new0bject;
        if (!ObjectPool.ContainsKey(prefab.name) || ObjectPool[prefab.name].Count == 0)
        {
            new0bject = GameObject.Instantiate(prefab);
            PushObject(new0bject);
            if (pool == null)
            {
                pool = new GameObject("ObjectPool");
            }
            GameObject childPool = GameObject.Find(prefab.name + "Pool");
            if (!childPool) 
            {
                childPool = new GameObject(prefab.name + "Pool");
                childPool.transform.SetParent(pool.transform);
            }
            new0bject.transform.SetParent(childPool.transform);
        }
        new0bject = ObjectPool[prefab.name].Dequeue();
        new0bject.SetActive(true);
        return new0bject;

    }

    public void PushObject(GameObject prefab)
    {
        string _name = prefab.name.Replace("(Clone)", string.Empty);
        if (!ObjectPool.ContainsKey(_name))
        {
            ObjectPool.Add(_name, new Queue<GameObject>());
        }
        ObjectPool[_name].Enqueue(prefab);
        prefab.SetActive(false);
    }
}
