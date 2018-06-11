using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{
    public string pool_item_name = string.Empty;
    public GameObject prefeb = null;
    public int poolCount = 0;

    [SerializeField]
    private List<GameObject> pool_list = new List<GameObject>();

    public void Init(Transform parent = null)
    {
        for(int i = 0; i < poolCount; i++)
        {
            pool_list.Add(CreateItem(parent));
        }
    }

    public void Push_To_Pool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        pool_list.Add(item);
    }

    public GameObject Pop_From_Pool(Transform parent = null)
    {
        if (pool_list.Count == 0)
            pool_list.Add(CreateItem(parent));

        GameObject item = pool_list[0];
        pool_list.RemoveAt(0);

        return item;
    }

    private GameObject CreateItem(Transform parent = null)
    {
        GameObject item = Object.Instantiate(prefeb) as GameObject;
        item.name = pool_item_name;
        item.transform.SetParent(parent);
        item.SetActive(false);

        return item;
    }
}
