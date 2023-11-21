using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponState
    {
        NORMAL,
        RELOAD,
        FIRING,
        EMPTY
    };
    WeaponState m_state =WeaponState.NORMAL;

    float m_internalTick;

    [SerializeField]
    float m_fireSpeed;

    [SerializeField]
    float m_reloadSpeed;

    [SerializeField]
    int m_ammoCapacity;

    int m_ammo;

    [SerializeField]
    int m_damage;

    [System.NonSerialized]
    public int m_fireSpeedLvl;
    
    [System.NonSerialized]
    public int m_reloadSpeedLvl;
    
    [System.NonSerialized]
    public int m_ammoCapacityLvl;
    
    [System.NonSerialized]
    public int m_damageLvl;


    [SerializeField]
    GameObject m_animalHitPrefab;

    [SerializeField]
    GameObject m_obstacleHitPrefab;

    [SerializeField]
    GameObject m_bulletPrefab;

    [SerializeField]
    AudioSource m_gunReloadingSource;

    [SerializeField]
    AudioSource m_gunFiringSource;

    void Start()
    {
        m_state =WeaponState.NORMAL;
        m_ammo =m_ammoCapacity;
    }
    
    void Update()
    {
        if (m_state ==WeaponState.RELOAD)
        {
            m_internalTick += Time.deltaTime;
            if (m_internalTick >=m_reloadSpeed)
            {
                m_internalTick=0f;
                m_state =WeaponState.NORMAL;
                m_ammo =m_ammoCapacity;
                m_gunReloadingSource.Play();
            }
        }
        else if (m_state ==WeaponState.FIRING)
        {
            m_internalTick += Time.deltaTime;
            if (m_internalTick >=m_fireSpeed)
            {
                m_internalTick=0f;
                m_state = m_ammo == 0 ? WeaponState.RELOAD : WeaponState.NORMAL;
            }
        }
    }
    
    bool CanShoot() { return WeaponState.NORMAL==m_state && m_ammo>0; }
    
    void VShoot()
    {
        m_state =WeaponState.FIRING;
        m_ammo--;
    }

    public void Shoot(Transform firePoint)
    {
        if (CanShoot())
        {
            VShoot();
            Vector2 firePoint2D =new Vector2(firePoint.transform.position.x, firePoint.transform.position.y);
            RaycastHit2D raycast =Physics2D.Raycast(firePoint2D, new Vector2(firePoint.up.x, firePoint.up.y), Mathf.Infinity, (1<<3)|(1<<9));
            if (raycast)
            {
                
                GameObject bullet = Instantiate(m_bulletPrefab, firePoint.position, firePoint.rotation);
                Enemy enemy =raycast.collider.gameObject.GetComponent<Enemy>();
                m_gunFiringSource.Play();

                if (enemy)
                {
                    Instantiate(m_animalHitPrefab,
                        new Vector3(raycast.point.x, raycast.point.y, 0f),
                        Quaternion.identity);

                    enemy.DoAttack(m_damage);
                }
                else
                {
                    Instantiate(m_obstacleHitPrefab,
                        new Vector3(raycast.point.x, raycast.point.y, 0f),
                        Quaternion.identity);
                }

                bullet.GetComponent<Bullet>().Init(raycast.point -firePoint2D, firePoint2D, raycast.point, enemy);

            }
        }
    }

    public void Upgrade()
    {
        m_fireSpeed = 0.2f-(m_fireSpeedLvl*0.6f);
        m_reloadSpeed =0.74f -(m_reloadSpeedLvl *0.7f);
        m_ammoCapacity =6+m_ammoCapacityLvl;
        m_damage =1 +m_damageLvl;
        m_ammo=m_ammoCapacity;

        m_state =WeaponState.NORMAL;
    }

};