using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBullet : Bullet
{
    [SerializeField]
    GameObject bullet;

    void Start()
    {
        Quaternion quat =transform.rotation;
        quat.eulerAngles += new Vector3(0f, 0f, 30f);
        Instantiate(bullet, transform.position, quat);
        quat.eulerAngles -= new Vector3(0f, 0f, 60f);
        Instantiate(bullet, transform.position, quat);
        Instantiate(bullet, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
