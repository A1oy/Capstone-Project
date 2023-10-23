using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Player player =null!;

    public Transform firePoint =null!;
    public GameObject bulletPrefab =null!;
    public GameObject grenadePrefab =null!;
    public GameObject honeyPrefab =null!;

    public float bulletForce = 5.0f;
    public float grenadeForce = 0.5f;
    public float honeyForce = 0.7f;

    void Start()
    {
        player =GetComponent<Player>();
    }

    void Update()
    {
        
		if (UIController.singleton!.isMovement)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(bulletPrefab, bulletForce);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                if (player.grenades >0)
                {
                    Shoot(grenadePrefab, grenadeForce);
                    player.grenades--;
                }
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                if (player.honey >0)
                {
                    Shoot(honeyPrefab, honeyForce);
                    player.honey--;
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
