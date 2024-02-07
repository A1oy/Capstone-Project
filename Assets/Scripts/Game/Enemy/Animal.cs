using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class Animal : MonoBehaviour
{
    Health health;
    WalkingFX animalWalking;

    void Awake()
    {
        health =GetComponent<Health>();
        animalWalking =GetComponent<WalkingFX>();
    }

    public void DoAttack(int damage, PlayerData player)
    {
        health.DoDamage(damage);
        if (health.health <= 0)
        {
            player.AddAnimalKilled();
        }
    }

    public static void PauseAllAnimals()
    {
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject animal in animals)
        {
            animal.GetComponent<Animal>().OnPause();
        }
    }

    public static void UnPauseAllAnimals()
    {
        GameObject[] animals =GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject animal in animals)
        {
            animal.GetComponent<Animal>().OnResume();
        }
    }

    public void OnPause()
    {
        animalWalking.StopWalking();
    }

    public void OnResume()
    {
        animalWalking.StartWalking();
    }

    void OnDead()
    {
        for (int i=0; i<transform.childCount; i++)
        {
            Transform child =transform.GetChild(i);
            if (child.gameObject.CompareTag("Damage"))
            {
                Destroy(child.gameObject);
            }
        }
        EnemySpawner.enemyAmt--;
        IPoolable poolable =GetComponent<IPoolable>();
        if (poolable)
        {
            poolable.Release();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}