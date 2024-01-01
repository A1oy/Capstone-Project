using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXPool<T> : MyPool<T> where T : IPoolable
{
    new public static GameObject Instantiate(Vector3 position, Quaternion quat)
    {
        return MyPool<T>.Instantiate(position, quat);
    }
}

public class BombExplodeFXPool : FXPool<IPoolable> {}