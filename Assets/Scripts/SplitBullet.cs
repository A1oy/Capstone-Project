using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBullet : Bullet
{
    override public void DoBulletTrigger(GameObject gameObj)
    {
        Quaternion quat =transform.rotation;
        ShotPool.Instantiate(transform.position, quat, player);
        quat.eulerAngles += new Vector3(0f, 0f, 30f);
        ShotPool.Instantiate(transform.position, quat, player);
        quat.eulerAngles -= new Vector3(0f, 0f, 60f);
        ShotPool.Instantiate(transform.position, quat, player);
    }
}
