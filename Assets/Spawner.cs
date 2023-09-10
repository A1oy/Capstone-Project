using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int maxEnemies;
    public int spawnDelay;
    public GameObject enemyPrefab;

    void Awake()
    {
        StartCoroutine(SpawningRoutine());
    }

    IEnumerator SpawningRoutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(spawnDelay);
        int i=maxEnemies;
        while (--i >0)
        {
            // do spawning ..
            Instantiate(enemyPrefab, transform);
            yield return waitTime;
        }
    }
}