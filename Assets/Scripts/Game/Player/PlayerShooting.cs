using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public enum WeaponState
    {
        NORMAL,
        RELOAD,
        FIRING,
        EMPTY
    };
    Sprite sprite;
    WeaponState m_state;

    float m_internalTick;

    float m_fireSpeed;
    float m_reloadSpeed;
    int m_ammoCapacity;
    int m_ammo;
    int m_damage;

    public int m_fireSpeedLvl;
    public int m_reloadSpeedLvl;
    public int m_ammoCapacityLvl;
    public int m_damageLvl;

    public Weapon()
    {
        m_fireSpeedLvl =0;
        m_reloadSpeedLvl =0;
        m_ammoCapacityLvl =0;
        m_damageLvl =0;

        m_fireSpeed =0.5f;
        m_reloadSpeed =1f;
        m_ammoCapacity =6;
        m_damage =1;
        m_ammo=m_ammoCapacity;
        m_state =WeaponState.NORMAL;
    }

    public Weapon(int fireSpeedLvl, int reloadSpeedLvl, int ammoCapacityLvl, int damageLvl)
    {
        m_fireSpeedLvl =fireSpeedLvl;
        m_reloadSpeedLvl =reloadSpeedLvl;
        m_ammoCapacityLvl =ammoCapacityLvl;
        m_damageLvl =damageLvl;

        m_fireSpeed = 0.9f-(fireSpeedLvl*0.6f);
        m_reloadSpeed =1f -(reloadSpeedLvl *0.7f);
        m_ammoCapacity =6+ammoCapacityLvl;
        m_damage =1 +m_damageLvl;
        m_ammo=m_ammoCapacity;

        m_state =WeaponState.NORMAL;
    }

    public void DoTick(float deltaTick)
    {
        if (m_state ==WeaponState.RELOAD)
        {
            m_internalTick += deltaTick;
            if (m_internalTick >=m_reloadSpeed)
            {
                m_internalTick=0f;
                m_state =WeaponState.NORMAL;
                m_ammo =m_ammoCapacity;
            }
        }
        else if (m_state ==WeaponState.FIRING)
        {
            m_internalTick += deltaTick;
            if (m_internalTick >=m_fireSpeed)
            {
                m_internalTick=0f;
                m_state = m_ammo == 0 ? WeaponState.RELOAD : WeaponState.NORMAL;
            }
        }
    }

    public bool CanShoot() { return WeaponState.NORMAL==m_state && m_ammo>0; }
    public void VShoot()
    {
        m_state =WeaponState.FIRING;
        m_ammo--;
    }
    public int Damage { get { return m_damage; }}
};

public class PlayerShooting : MonoBehaviour
{   
    [SerializeField]
    GameObject m_bulletPrefab;

    [SerializeField]
    GameObject m_explodePrefab;
    
    [SerializeField]
    float bulletForce;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    PlayerStatus status;

    [System.NonSerialized]
    public Weapon weapon = new Weapon();

    void Update()
    {
        
		if (MenuManager.singleton!.isMovement
            && !status.isBuildMode)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                ShootWeapon();
            }
        }
        weapon.DoTick(Time.deltaTime);
    }

    void ShootWeapon()
    {
        if (weapon.CanShoot())
        {
            weapon.VShoot();
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
                    enemy.DoAttack(weapon.Damage);
                }
            }
        }
    }
}