using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public bool isKilled =false;
    public int health;
    
    int maxHealth=1;

    [SerializeField]
    GameObject healthBar;

    void Start()
    {
        maxHealth =health;
    }

    public bool DoDamage(int damage)
    {
        health -=damage;
        if (health <=0)
        {
            isKilled =true;
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    void Update()
    {
        if (healthBar)
        {
            healthBar.GetComponent<Slider>().value = (float)health/(float)maxHealth;
        }
    }
}
