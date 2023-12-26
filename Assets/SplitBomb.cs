using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBomb : Bomb
{
    [SerializeField]
    GameObject bulletPrefab;

    override public void DoBulletTrigger(GameObject gameobj)
    {
        Vector3 angleDelta = new Vector3(0f, 0f, Random.value >0.5f ? -45f : 45f);
        Quaternion quat =Quaternion.identity;
        Instantiate(bulletPrefab,
                transform.position,
                quat);
        quat.eulerAngles += angleDelta;
        Instantiate(bulletPrefab,
                transform.position,
                quat);
        base.DoBulletTrigger(gameobj);
    }
}
