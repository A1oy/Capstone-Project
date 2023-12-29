using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWarning : MonoBehaviour
{
    Health health;
    
    [SerializeField]
    float redThreshold;

    [SerializeField]
    Image image;

    void Awake()
    {
        health =NetworkManager0.GetLocalPlayer()
            .GetComponent<Health>();
    }

    void FixedUpdate()
    {
        float alpha = 1f - ((float)health.GetCurrentHealth()/health.GetMaxHealth());
        if (alpha >redThreshold)
        {
            alpha =redThreshold;
        }
        SpriteRenderer sr =GetComponent<SpriteRenderer>();
        image.color = new Color(1f, 0f, 0f, alpha);
    }
}
