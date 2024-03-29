using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class IPoolable : MonoBehaviour
{
   public IObjectPool<GameObject>? pool;

   public virtual void Release()
   {
      if (pool==null)
      {
         Destroy(gameObject);
      }
      else
      {
         pool.Release(gameObject);
      }
   }
}