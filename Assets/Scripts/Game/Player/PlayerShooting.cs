using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    public Transform firePoint =null!;
    public GameObject bulletPrefab =null!;
    public GameObject grenadePrefab =null!;
    public GameObject honeyPrefab =null!;

    public float bulletForce = 5.0f;
    public float grenadeForce = 0.5f;
    public float honeyForce = 0.7f;


    [SerializeField]
    PlayerInventory inventory;


    void Update()
    {
        
		if (MenuManager.singleton!.isMovement
            && !GetComponent<Player>().isBuildMode)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(bulletPrefab, bulletForce);
            }
            /*
            else if (Input.GetButtonDown("Fire2"))
            {
                if (inventory.grenades >0)
                {
                    Shoot(grenadePrefab, grenadeForce);
                    inventory.grenades--;
                }
            }
            */
            else if (Input.GetButtonDown("Fire3"))
            {
                if (inventory.honey >0)
                {
                    Shoot(honeyPrefab, honeyForce);
                    inventory.honey--;
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
