using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool
{
    List<GameObject> pooledObjs;
    GameObject prefab;

    public GenericPool(GameObject prefab, int initialCount=100)
    {
        this.prefab =prefab;
        this.pooledObjs = new List<GameObject>();
        for (int i=0; i<100;i++)
        {
            GameObject g =Object.Instantiate(prefab);
            g.SetActive(false);
            this.pooledObjs.Add(g);
        }
    }
    public GameObject InstantiateObject(Vector3 position, Quaternion rotation)
    {
        foreach (GameObject g in pooledObjs)
        {
            if (!g.activeInHierarchy)
            {
                g.transform.position =position;
                g.transform.rotation =rotation;
                g.SetActive(true);
                return g;
            }
        }
        GameObject gameobj =Object.Instantiate(prefab, position, rotation);
        pooledObjs.Add(gameobj);
        return gameobj;
    }

    public void FreeObject(GameObject gameobj)
    {
        gameobj.SetActive(false);
    }
}
