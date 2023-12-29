using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


/*
This code kinda sucks but it will do
TODO: Refactor?
*/
public class MyPoolBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject prefab;
}

public class MyPool<T>  : MyPoolBase where T: IPoolable
{
    void OnEnable()
    {
        MyPool<T>.prefabRef =prefab;
    }

    void OnDisable()
    {
        prefabRef =null;
        pool =null;
    }

    static GameObject prefabRef;
    public static IObjectPool<GameObject> pool =new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 100, 1000);

    static GameObject CreatePooledItem()
    {
        GameObject go =Instantiate(prefabRef);
        ((IPoolable)go.GetComponent<T>()).pool = MyPool<T>.pool;
        return go;
    }
    static void OnReturnedToPool(GameObject go)
    {
        go.SetActive(false);
    }

    static void OnTakeFromPool(GameObject go)
    {
        go.SetActive(true);
    }
    static void OnDestroyPoolObject(GameObject go)
    {
        Destroy(go);
    }

    static protected GameObject Instantiate(Vector3 position, Quaternion rotation)
    {
        GameObject go =pool.Get();
        go.transform.position =position;
        go.transform.rotation = rotation;

        return go;
    }
}
