using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWarning : MonoBehaviour
{
    Health healthComp =null!;
    float initialHealth;

    public GameObject playerRef =null!;
    public float redThreshold =0.75f;

    void Start()
    {
        healthComp =playerRef.GetComponent<Health>();
        initialHealth =(float)healthComp.health;
    }

    void FixedUpdate()
    {
        float alpha = 1.0f - (healthComp.health/initialHealth);
        if (alpha >redThreshold)
        {
            alpha =redThreshold;
        }
        SpriteRenderer sr =GetComponent<SpriteRenderer>();
        sr.color = new Color(1.0f, 0.0f, 0.0f, alpha);
    }
}
