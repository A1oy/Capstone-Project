using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool<T> : MyPool<T> where T : Bullet
{
    public static GameObject Instantiate(Vector3 position, Quaternion rotation, PlayerData player)
    {
        GameObject go =MyPool<T>.Instantiate(position, rotation);
        go.GetComponent<Bullet>().player = player;
        return go;
    }
}
