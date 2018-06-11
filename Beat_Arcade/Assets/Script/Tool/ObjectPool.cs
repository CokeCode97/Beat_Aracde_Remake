using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool> {
    public List<PooledObject> object_pool = new List<PooledObject>();

    void Awake()
    {
        for(int i = 0; i < object_pool.Count; i++)
        {
            object_pool[i].Init(transform);
        }
    }

    public bool Push_To_Pool(GameObject item, string item_name, Transform parent = null)
    {
        PooledObject pool = Get_Pool_Item(item_name);
        if (pool == null)
            return false;

        pool.Push_To_Pool(item, parent == null ? transform : parent);
        return true;
    }

    public GameObject Pop_From_Pool(string item_name, Transform parent = null)
    {
        PooledObject pool = Get_Pool_Item(item_name);
        if (pool == null)
            return null;

        return pool.Pop_From_Pool(parent);
    }

    PooledObject Get_Pool_Item(string item_name)
    {
        for(int i = 0; i < object_pool.Count; i++)
        {
            if (object_pool[i].pool_item_name.Equals(item_name))
                return object_pool[i];
        }

        return null;
    }
}
