using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MyPool2 : MonoBehaviour
{
    [SerializeField]
    GameObject gamePrefab;

    IObjectPool<GameObject> pool;

    void OnEnable()
    {
         pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 100, 1000);
    }

    GameObject CreatePooledItem()
    {
        GameObject go =Instantiate(gamePrefab);
        (go.GetComponent<IPoolable>()).pool = pool;
        return go;
    }
    
    void OnReturnedToPool(GameObject go)
    {
        go.SetActive(false);
    }

    void OnTakeFromPool(GameObject go)
    {
        go.SetActive(true);
    }
    
    void OnDestroyPoolObject(GameObject go)
    {
        Destroy(go);
    }

    public GameObject Instantiate(Vector3 position, Quaternion rotation)
    {
        GameObject go =pool.Get();
        go.transform.position =position;
        go.transform.rotation = rotation;

        return go;
    }
}
