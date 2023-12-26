using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBullet : Bullet
{
    [SerializeField]
    GameObject knifeBullet;

    override public void DoBulletTrigger(GameObject gameObj)
    {
        Instantiate(knifeBullet, transform.position, transform.rotation);
    }
}
