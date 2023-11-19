using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWarning : MonoBehaviour
{
    Health m_health =null!;
    float initialHealth;

    public GameObject playerRef =null!;
    public float redThreshold =0.75f;

    void Awake()
    {
        m_health =playerRef.GetComponent<Health>();
        initialHealth =(float)m_health.GetCurrentHealth();
    }

    void FixedUpdate()
    {
        float alpha = 1.0f - (m_health.GetCurrentHealth()/initialHealth);
        if (alpha >redThreshold)
        {
            alpha =redThreshold;
        }
        SpriteRenderer sr =GetComponent<SpriteRenderer>();
        sr.color = new Color(1.0f, 0.0f, 0.0f, alpha);
    }
}
