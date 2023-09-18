using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject grenadePrefab;

    public float bulletForce = 20f;
    public float grenadeForce = 2f;

    public int baseDamage =0;

    // Update is called once per frame
    void Update()
    {
		if (!Pause.isPaused)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(bulletPrefab, bulletForce);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Shoot(grenadePrefab, grenadeForce);
            }
        }
    }

    void Shoot(GameObject projectile, float force)
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Bullet bulletComponent =bullet.GetComponent<Bullet>();
        if (bulletComponent)
        {
            bulletComponent.damage += baseDamage;
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
}
