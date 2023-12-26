using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet
{
    override public void DoBulletTrigger(GameObject gameobj)
    {
        GameObject go =BombExplodeFXPool.Instantiate(transform.position,
            Quaternion.identity);
        go.GetComponentInChildren<ParticleSystem>().Play();
    }
}