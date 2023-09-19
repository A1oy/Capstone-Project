using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject grenadePrefab;

    public float cooldown =0;

    public float bulletForce = 2.0f;
    public float grenadeForce = 2f;

    public int baseDamage =0;
    public float cooldownDelay =5;

    // Update is called once per frame
    void Update()
    {
		if (!Pause.isPaused)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(bulletPrefab, bulletForce);
            }
            else if (Input.GetButtonDown("Fire2")
                && cooldown ==0)
            {
                Shoot(grenadePrefab, grenadeForce);
                cooldown =cooldownDelay;

            }
        }
        if (cooldown >0.0f)
        {
            cooldown -=Time.deltaTime;
            if (cooldown <0.0f)
            {
                cooldown =0.0f;
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
