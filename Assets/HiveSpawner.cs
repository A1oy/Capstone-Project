using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveSpawner : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D spawnArea;

    Transform player;

    [SerializeField]
    float spawnFrequencyInSeconds;

    [SerializeField]
    int numberOfHivesToSpawn;

    [SerializeField]
    int numberOfHivesLeftToBecomeActive;

    [SerializeField]
    float playerRadius;

    [SerializeField]
    float radiusSquared;

    [SerializeField]
    GameObject hivePrefab;

    bool isActive =true;

    [SerializeField]
    float cooldown;

    List<GameObject> hives =new List<GameObject>();


    void Awake()
    {
        cooldown =spawnFrequencyInSeconds/2f;
        player =GameObject.FindWithTag("Player").transform;
        radiusSquared =playerRadius *playerRadius;
    }

    void Update()
    {
        if (!isActive)
        {
            CheckHiveActive();       
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <0f)
        {
            SpawnHives();
            isActive =false;
            cooldown =spawnFrequencyInSeconds;
        }
    }

    void CheckHiveActive()
    {
        foreach (GameObject go in hives)
        {
            if (!go)
            {
                hives.Remove(go);
            }
        }
        if (hives.Count < numberOfHivesLeftToBecomeActive)
        {
            isActive =true;
        }
    }

    void SpawnHives()
    {
        int numberToSpawn =numberOfHivesToSpawn -hives.Count;
        for (int i=0; i<numberToSpawn; i++)
        {
            Vector3 loc =GetSpawnLocation();
            hives.Add(Instantiate(hivePrefab, loc, Quaternion.identity));
        }        
    }

    Vector3 GetSpawnLocation()
    {
        const int iters =1000;
        for  (int i=0; i<iters; i++)
        {
            bool ok=true;
            float randomX = UnityEngine.Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            float randomY = UnityEngine.Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            float x =randomX;
            float y =randomY;
            randomX -= player.position.x;
            randomY -= player.position.y;
            randomX *= randomX;
            randomY *= randomY;
            foreach (GameObject hive in hives)
            {
                if (hive)
                {
                    float dx =x-hive.transform.position.x;
                    float dy =y-hive.transform.position.y;
                    dx *=dx;
                    dy *=dy;

                    if ((dx+dy) <radiusSquared)
                    {
                        ok =false;
                        break;
                    }
                }
            }
            if (!ok)
            {
                continue;
            }
            if (radiusSquared <= (randomX+randomY))
            {
                return new Vector3(x, y, 0f);
            }
        }
        return Vector3.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color =new Color(0.3f, 0.5f, 0.6f, 0.4f);
        Gizmos.DrawSphere(player.position, playerRadius);
    }
}
