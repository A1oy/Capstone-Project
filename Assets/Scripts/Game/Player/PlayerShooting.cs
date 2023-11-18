using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{   
    [SerializeField]
    float bulletForce;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    PlayerStatus status;

    [SerializeField]
    public Weapon weapon;

    void Update()
    {
        
		if (MenuManager.singleton!.isMovement
            && !status.isBuildMode)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.Shoot(firePoint);
            }
        }
    }
}