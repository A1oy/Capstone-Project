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
    public enum BulletType
    {
        Normal =0,
        Radial,
        Split,
        Bomb,
        ClusterBomb,
        SplitBomb
    };

    ShotType shot =ShotType.Single;
    BulletType bullet =BulletType.Normal;

    [SerializeField]
    PlayerController controller;

    [SerializeField]
    int numShootPerFrames;

    int curShootFrame =0;

    [SerializeField]
    Transform firePoint;

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
                    DoShoot();
                }
            }
          
        }
    }

    public void DoShoot()
    {
        if (shot ==ShotType.Single)
        {
            ShotPool.Instantiate(transform.position, firePoint.rotation);
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
                    ShootSpread(SplitShotPool.pool, transform.position, firePoint.rotation);
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
    }

    public void SetUpgrade(UpgradeData data)
    {
        shot =data.shot;
        bullet =data.bullet;
    }
}