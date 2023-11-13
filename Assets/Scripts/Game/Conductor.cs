using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Conductor : MonoBehaviour
{
    [SerializeField]
    Health playerHealth;

    [SerializeField]
    PlayerInventory inventory;

    [SerializeField]
    GameObject rabbitPrefab;
    
    [SerializeField]
    GameObject squirrelPrefab;

    [SerializeField]
    GameObject foxPrefab;

    [SerializeField]
    List<BoxCollider2D> spawnLocations;

    [SerializeField]
    float dayTunningCoeff;

    [SerializeField]
    float playerHPTunningCoeff;
    
    [SerializeField]
    float playerItemTunningCoeff;

    [SerializeField]
    float honeyTunningCoeff;

    [SerializeField]
    float biasTunningCoeff;

    [SerializeField]
    float internalDiff;

    float spawnCoolDown;

    [SerializeField]
    float spawnTime =0;

    void Update()
    {
        if (!GameUI.isDaytime)
        {
            internalDiff =GameUI.day * dayTunningCoeff +
            playerHealth.health * playerHPTunningCoeff +
            playerItemTunningCoeff * inventory.itemSlots.Count +
            honeyTunningCoeff * inventory.honey -
            biasTunningCoeff;

            int numRabbit=0;
            int numSquirrel =0;
            int numFox =0;
            int enumDiff =0;

            spawnTime -= Time.deltaTime;

            if (internalDiff <1.5f)
            {
                float internalBias =(internalDiff)/ 1.5f;
                numRabbit =Random.Range(1 +(int)(internalBias*2.6666f), 5);
                spawnCoolDown =20.3f- internalDiff-0.6f;
            }
            else if (internalDiff <2.1f)
            {
                float internalBias =(internalDiff-1.5f) /0.6f;
                enumDiff =0;
                numRabbit =Random.Range(1 +(int)(internalBias*2.6666f)+1, 6);
                numSquirrel =Random.Range(1 +(int)(internalBias*0.6666f), 3);
                spawnCoolDown =15.3f+ internalDiff-0.6f;
            }
            else
            {
                float internalBias =internalDiff-2.1f;
                if (internalBias >2f)
                {
                    internalBias =2f;
                }
                numRabbit =Random.Range(1 +(int)(internalBias*2.6666f)+1, 10);
                numSquirrel =Random.Range(1 +(int)(internalBias*0.6666f), 5);
                spawnCoolDown =11.3f- internalDiff-0.5f;
            }

            if (spawnTime<0)
            {
                SpawnEnemies(rabbitPrefab, numRabbit, enumDiff);
                SpawnEnemies(squirrelPrefab, numSquirrel, enumDiff);
                SpawnEnemies(foxPrefab, numFox, enumDiff);
                spawnTime =spawnCoolDown;
            }
        }
    }

    void SpawnEnemies(GameObject enemyPrefab, int count, int enumDiff)
    {
        for (int i=0;
            i<count;
            i++)
        {
            int randBox =Random.Range(0, spawnLocations.Count);
            Bounds bound = spawnLocations[randBox].bounds;
            float  x = Random.Range(bound.min.x+2f, bound.max.x-2f);
            float y = Random.Range(bound.min.y +2f, bound.max.y-2f);
            Instantiate(enemyPrefab, new Vector3(x, y, 0f), Quaternion.identity);
        }
    }
}
