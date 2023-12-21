using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBullet : Bullet
{
    [SerializeField]
    GameObject bullet;

    override public void DoBulletTrigger(GameObject gameObj)
    {
        Quaternion quat =Quaternion.identity;
        for (int i=0; i<3;i++)
        {
            Instantiate(bullet, transform.position, quat);
            quat.eulerAngles += new Vector3(0f, 0f, 120f);                
        }
    }
}