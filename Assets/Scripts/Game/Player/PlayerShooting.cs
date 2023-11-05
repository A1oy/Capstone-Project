using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    public Transform firePoint =null!;
    public GameObject bulletPrefab =null!;
    public GameObject grenadePrefab =null!;
    public GameObject honeyPrefab =null!;

    public float bulletForce;
    public float honeyForce;


    [SerializeField]
    PlayerInventory inventory;

    [SerializeField]
    PlayerStatus status;

    void Update()
    {
        
		if (MenuManager.singleton!.isMovement
            && !status.isBuildMode)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(bulletPrefab, bulletForce);
            }
            
            else if (Input.GetButtonDown("Fire2"))
            {
                inventory.UseItem(firePoint);
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                if (inventory.honey >=5)
                {
                    Shoot(honeyPrefab, honeyForce);
                    inventory.honey-=5;
                }
            }
        }
    }
    
    void Shoot(GameObject projectile, float force)
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Bullet bulletComponent =bullet.GetComponent<Bullet>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
}
