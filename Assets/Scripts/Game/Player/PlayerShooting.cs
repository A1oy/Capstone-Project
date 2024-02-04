using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{   
    public enum ShotType
    {
        Single,
        Multi
    };

    public enum BulletType : int
    {
        Normal = 0,
        Radial = 1,
        Split = 2,  //add a feature where for every 5 kills, shoots 3 shots next 
        SplitII = 3, //splitII skill (shoots additional 2 shots
        DoubleShot = 4, //shots 1 extra shot regularly/reduce fire rate by 20%
        Bomb = 5,
        ClusterBomb = 6,
        SplitBomb = 7
    };

    ShotType shot =ShotType.Single;
    BulletType bullet =BulletType.Normal;

    [SerializeField]
    PlayerData player;

    [SerializeField]
    PlayerController controller;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    int numShootPerFrames;

    int curShootFrame =0;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    AudioSource shootSfx;

    List<PostShotBehaviourCommand> psbcs = new List<PostShotBehaviourCommand>();
    List<ShotBehaviourCommand> sbcs = new List<ShotBehaviourCommand>();

    void Awake()
    {
        bulletPrefab.GetComponent<Bullet>().player =player;
        sbcs.Add(new SplitShotCommand(player));
    }


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
                    Shoot();
                }
            }
          
        }
    }

    public bool PlayerHasFiveKills() => player.animalsKilled == 5;

    public void DoShoot()
    {
        shootSfx.Play();
        if (shot == ShotType.Single)
        {
            ShotPool.Instantiate(transform.position, firePoint.rotation, player);
        }
        else if (shot ==ShotType.Multi)
        {
            switch (bullet)
            {
                case BulletType.Normal:
                    ShootSpread(ShotPool.pool, transform.position, firePoint.rotation);
                    break;
                case BulletType.Bomb:
                    ShootSpread(BombPool.pool, transform.position, firePoint.rotation);
                    break;
                case BulletType.ClusterBomb:
                    ShootSpread(ClusterBombPool.pool, transform.position, firePoint.rotation);
                    break;
                case BulletType.SplitBomb:
                    ShootSpread(SplitBombPool.pool, transform.position, firePoint.rotation);
                    break;
                case BulletType.Radial:
                    ShootSpread(RadialShotPool.pool, transform.position, firePoint.rotation);
                    break;
                case BulletType.Split:

                    break;
                case BulletType.SplitII:
                    //Implementation
                    break;
                case BulletType.DoubleShot:
                    //Implementation
                    break; 
            }
        }
    }

    void ShootSpread(IObjectPool<GameObject> pool, Vector3 position, Quaternion quat)
    {
        quat.eulerAngles += new Vector3(0f, 0f, 30f);
        GameObject go =pool.Get(); 
        Init(go, position, quat);
        quat.eulerAngles -= new Vector3(0f, 0f, 60f);
        go =pool.Get();
        Init(go, position, quat);
        quat.eulerAngles += new Vector3(0f, 0f, 30f);
        go =pool.Get();
        Init(go, position, quat);
    }

    void Init(GameObject go, Vector3 position, Quaternion quat)
    {
        go.transform.position =position;
        go.transform.rotation =quat;
        go.GetComponent<Bullet>().player = player;
    }

    public void SetUpgrade(UpgradeData data)
    {
        shot =data.shot;
        bullet =data.bullet;
    }

    /*
    public void AddShotBehaviourCommand(ShotBehaviourCommand sbc)
    {
        sbcs.Add(sbc);
        sbcs.Sort(); 
    }

    public void AddPostShotBehaviourCommand(PostShotBehaviourCommand psbc)
    {
        psbcs.Add(psbc);
        psbcs.Sort(); 
    }
    */ 

    public void Shoot()
    {
        List<GameObject> bullets = new List<GameObject> { }; 
        bullets.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));

        foreach(ShotBehaviourCommand sbc in sbcs) {
            sbc.Execute(firePoint, bulletPrefab, bullets); 
        }

        foreach(PostShotBehaviourCommand psbc in psbcs) {
            foreach(GameObject bullet in bullets) {
                psbc.Apply(bullet);
            }
        }

        foreach(GameObject bullet in bullets) {
            bullet.SetActive(true);
        }
        bullets.Clear();
    }
}