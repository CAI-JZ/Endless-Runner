using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPool:MonoBehaviour
{
    private ObjectPool() {}

    //-> lazy loading
    public static ObjectPool Instance
    {
        get
        {
            return instance;
        }
    }

    private static ObjectPool instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            throw new UnityException("ÒÑÓÐÊµÀý£º" + name);
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
            GameObject childPool = GameObject.Find(prefab.name + "Pool");
            if (!childPool) 
            {
                childPool = new GameObject(prefab.name + "Pool");
                childPool.transform.SetParent(gameObject.transform);
            }
            new0bject.transform.SetParent(childPool.transform);
            PushObject(new0bject);
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
