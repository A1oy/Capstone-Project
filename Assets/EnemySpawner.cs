using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] animalPrefabs;

    [SerializeField]
    Transform player;

    [SerializeField]
    BoxCollider2D spawningArea;

    [SerializeField]
    int spawnMaxAmount;

    [SerializeField]
    float cooldown;

    [SerializeField]
    float radius;

    float radiusSquared;

    [SerializeField]
    float timeSinceSpawn;

    void Awake()
    {
        radiusSquared =radius*radius;
    }

    void FixedUpdate()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >=cooldown)
        {
            timeSinceSpawn =0f;
            StartCoroutine(DoAnimalSpawning());
        }
    }

    IEnumerator DoAnimalSpawning()
    {
        for (int i=0; i<spawnMaxAmount; i++)
        {
            Vector3 luckyDraw =DoLuckyDraw();
            int randAnimalIndex =(int)Random.Range(0, animalPrefabs.Length);

            Instantiate(animalPrefabs[randAnimalIndex],
                luckyDraw,
                Quaternion.identity);
        }
        

        return null;
    }

    Vector3 DoLuckyDraw()
    {
        const int iters =1000;
        for (int i=0; i<iters; i++)
        {
            float randomX = Random.Range(spawningArea.bounds.min.x, spawningArea.bounds.max.x);
            float randomY = Random.Range(spawningArea.bounds.min.y, spawningArea.bounds.max.y);
            float x =randomX;
            float y =randomY;
            randomX -= player.position.x;
            randomY -= player.position.y;
            randomX *= randomX;
            randomY *= randomY;
            
            if (radiusSquared <= (randomX+randomY))
            {
                return new Vector3(x, y, 0f);
                break;
            }
        }
        return Vector3.zero;
    }
}
