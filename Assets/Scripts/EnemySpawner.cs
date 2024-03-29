using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct EnemySpawn
{
    [SerializeField]
    public MyPool2 animal;
    
    [SerializeField]
    [Range(0, 1)]
    public float probabilityOfSpawning;
}

[Serializable]
public struct Wave
{
    [SerializeField]
    public int startAtWave;

    [SerializeField]
    public EnemySpawn[] enemySpawnings;

    [SerializeField]
    public float cooldown;

    [SerializeField]
    public int spawnRate;

    [SerializeField]
    public int spawnMaxAmount;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    BoxCollider2D spawningArea;

    [SerializeField]
    float radius;

    float radiusSquared;

    [SerializeField]
    float timeSinceSpawn;

    [SerializeField]
    Wave[] waves;

    UnityAction<int> dayChangeAction;

    int curWaveIndex;

    public static int enemyAmt;

    void Awake()
    {
        enemyAmt =0;
        radiusSquared =radius*radius;
    }

    void Start()
    {
        dayChangeAction += OnDayChange;
        GameObject.Find("GameManager")
            .GetComponent<GameUI>()
            .AddDayChangeListener(dayChangeAction);
    }

    void OnDayChange(int day)
    {
        if (curWaveIndex != (waves.Length-1) && day ==waves[curWaveIndex+1].startAtWave)
        {
           curWaveIndex++;
           timeSinceSpawn =0f;
        }
    }

    void FixedUpdate()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >=waves[curWaveIndex].cooldown)
        {
            timeSinceSpawn =0f;
            StartCoroutine(DoAnimalSpawning());
        }
    }

    IEnumerator DoAnimalSpawning()
    {
        int i=0;
        while (i<waves[curWaveIndex].spawnRate && enemyAmt<waves[curWaveIndex].spawnMaxAmount)
        {
            i++;
            enemyAmt++;
            Vector3 luckyDraw =DoLuckyDraw();
            MyPool2 animal =PickAnimal(waves[curWaveIndex].enemySpawnings);
            animal.Instantiate(luckyDraw, Quaternion.identity);
//            Instantiate(animal, luckyDraw, Quaternion.identity);
        }
        yield return new WaitForSeconds(0f);
    }

    MyPool2 PickAnimal(EnemySpawn[] enemySpawnings)
    {
        for (int i=0; i<enemySpawnings.Length; i++)
        {
            if (UnityEngine.Random.value <= enemySpawnings[i].probabilityOfSpawning)
            {
                return enemySpawnings[i].animal;
            }
        }
        return enemySpawnings[enemySpawnings.Length-1].animal;
    }

    Vector3 DoLuckyDraw()
    {
        const int iters =1000;
        for (int i=0; i<iters; i++)
        {
            float randomX = UnityEngine.Random.Range(spawningArea.bounds.min.x, spawningArea.bounds.max.x);
            float randomY = UnityEngine.Random.Range(spawningArea.bounds.min.y, spawningArea.bounds.max.y);
            float x =randomX;
            float y =randomY;
            randomX -= player.position.x;
            randomY -= player.position.y;
            randomX *= randomX;
            randomY *= randomY;
            
            if (radiusSquared <= (randomX+randomY))
            {
                return new Vector3(x, y, 0f);
            }
        }
        return Vector3.zero;
    }
}
