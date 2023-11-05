using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    [SerializeField]
    GameObject m_bulletPrefab;

    [SerializeField]
    GameObject m_explodePrefab;
    
    [SerializeField]
    GameObject m_honeyPrefab;

    [SerializeField]
    float bulletForce;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    float m_honeyForce;

    [SerializeField]
    PlayerInventory m_inventory;

    [SerializeField]
    PlayerStatus status;

    void Update()
    {
        
		if (MenuManager.singleton!.isMovement
            && !status.isBuildMode)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                ShootWeapon();
            }
            
            else if (Input.GetButtonDown("Fire2"))
            {
                m_inventory.UseItem(firePoint);
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                ShootHoney();
            }
        }
    }
    
    void ShootWeapon()
    {
        /*
        GameObject bullet = Instantiate(m_bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletComponent =bullet.GetComponent<Bullet>();
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * 6f, ForceMode2D.Impulse);
        */
        Vector2 firePoint2D =new Vector2(firePoint.transform.position.x, firePoint.transform.position.y);
        RaycastHit2D raycast =Physics2D.Raycast(firePoint2D, new Vector2(firePoint.up.x, firePoint.up.y));
        if (raycast)
        {
            GameObject explosion =Instantiate(m_explodePrefab, new Vector3(raycast.point.x, raycast.point.y, 0f), Quaternion.identity);
            Destroy(explosion, 1f);
            
            GameObject bullet = Instantiate(m_bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().Shoot(raycast.point -firePoint2D, firePoint2D);

            Enemy enemy =raycast.collider.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.DoAttack(m_inventory.weapon.m_damage);
            }
        }
    }

    void ShootHoney()
    {
        if (m_inventory.honey >=5)
        {
            GameObject bullet = Instantiate(m_honeyPrefab, firePoint.position, firePoint.rotation);
            Bullet bulletComponent =bullet.GetComponent<Bullet>();
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce(firePoint.up * m_honeyForce, ForceMode2D.Impulse);
            m_inventory.honey -=5;
        }
        
    }
}
