using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{   
    [SerializeField]
    PlayerController controller;

    [SerializeField]
    int numShootPerFrames;

    int curShootFrame =0;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    public GameObject bullet;

    void FixedUpdate()
    {
        if (controller.Move())
		{
            curShootFrame++;
            if (curShootFrame==numShootPerFrames)
            {
                curShootFrame=0;
                if (Input.GetButton("Fire1"))
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }
          
        }
    }
}