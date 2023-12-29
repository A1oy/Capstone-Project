using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBomb : Bomb
{
    [SerializeField]
    GameObject bombPrefab;
    
    override public void DoBulletTrigger(GameObject gameObj)
    {
         Vector3 angleDelta = new Vector3(0f, 0f, Random.value >0.5f ? -45f : 45f);
        Quaternion quat =Quaternion.identity;
        quat.eulerAngles += angleDelta;
        BombPool.Instantiate(transform.position, quat, player);
    }
}
