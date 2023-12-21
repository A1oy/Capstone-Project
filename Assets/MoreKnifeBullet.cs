using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreKnifeBullet : Bullet
{
    [SerializeField]
    GameObject knifebullet;

    override public void DoBulletTrigger(GameObject gameObj)
    {
        Instantiate(knifebullet, transform.position, transform.rotation);
    }
}
