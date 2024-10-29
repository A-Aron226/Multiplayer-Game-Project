using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


[System.Serializable]
public class  ObjectPoolItem
{
    //Variables to call in inspector
    public GameObject item;
    public int itemAmount;
    public bool expandPool = false;
}
public class HealthPackPool : MonoBehaviour
{
    public static HealthPackPool SharedInstance;
    public List<GameObject> pooledItems; //List of how many objects are being pooled in hierarchy
    public List<ObjectPoolItem> itemsToPool; //List of what types of objects to pool

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Adds GameObjects onto the Hierarchy at the start of Runtime
        pooledItems = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            GameObject tmp;

            for (int i = 0; i < item.itemAmount; i++)
            {
                tmp = (GameObject)Instantiate(item.item);
                tmp.SetActive(false);
                pooledItems.Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject(string tag) //Takes a string parameter to call for a certain inactive object in the pool
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                return pooledItems[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.item.tag == tag)
            {
                if (item.expandPool)
                {
                    GameObject obj = (GameObject)Instantiate(item.item);
                    obj.SetActive(false);
                    pooledItems.Add(obj);
                    return obj;
                }                
            }
        }
        return null;
    }
}
