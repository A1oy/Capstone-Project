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
            Instantiate(enemyPrefab, (new Vector3(0.0f, Random.Range(-4.0f, 4.0f), 0.0f)) + transform.position, Quaternion.identity);
            yield return waitTime;
        }
    }
}