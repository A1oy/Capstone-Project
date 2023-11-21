using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWarning : MonoBehaviour
{
    Health m_health;

    [SerializeField]
    GameObject playerRef;
    
    [SerializeField]
    float redThreshold;

    [SerializeField]
    Image image;

    void Awake()
    {
        m_health =playerRef.GetComponent<Health>();
    }

    void FixedUpdate()
    {
        float alpha = 1f - ((float)m_health.GetCurrentHealth()/m_health.GetMaxHealth());
        if (alpha >redThreshold)
        {
            alpha =redThreshold;
        }
        SpriteRenderer sr =GetComponent<SpriteRenderer>();
        image.color = new Color(1f, 0f, 0f, alpha);
    }
}
