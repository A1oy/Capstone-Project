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
    GameUI gameUI;

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

    bool isFirstTime=true;

    bool isActive =false;

    void Update()
    {
        if (isActive)
        {
            internalDiff =gameUI.day * dayTunningCoeff +
            playerHealth.GetHealth() * playerHPTunningCoeff +
            playerItemTunningCoeff * inventory.itemSlots.Count +
            honeyTunningCoeff * inventory.honey -
            biasTunningCoeff;

            int numRabbit=0;
            int numSquirrel =0;
            int numFox =0;
            int enumDiff =0;

            if (internalDiff <1.5f)
            {
                float internalBias =(internalDiff)/ 1.5f;
                numRabbit =Random.Range(1 +(int)(internalBias*2.6666f), 5);
                
            }
            else if (internalDiff <2.1f)
            {
                float internalBias =(internalDiff-1.5f) /0.6f;
                enumDiff =0;
                numRabbit =Random.Range(2 +(int)(internalBias*0.9666f), 6);
                numSquirrel =Random.Range(1 +(int)(internalBias*0.3666f), 3);
            }
            else
            {
                float internalBias =internalDiff-2.1f;
                if (internalBias >2f)
                {
                    internalBias =2f;
                }
                numRabbit =Random.Range(3 +(int)(internalBias*0.366f), 10);
                numSquirrel =Random.Range(2 +(int)(internalBias*0.1666f), 5);
            }
            spawnTime -= Time.deltaTime;
            if (spawnTime<0)
            {
                SpawnEnemies(rabbitPrefab, numRabbit, enumDiff);
                SpawnEnemies(squirrelPrefab, numSquirrel, enumDiff);
                SpawnEnemies(foxPrefab, numFox, enumDiff);
                CalculateCooldown();
            }
        }
    }

    void CalculateCooldown()
    {
        spawnCoolDown =17.3f- internalDiff*0.6f-0.6f;
        spawnTime =spawnCoolDown;
    }

    void OnDaylightChange(bool isDayTime)
    {
        isActive =!isDayTime;
        if (isFirstTime)
        {
            CalculateCooldown();
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
