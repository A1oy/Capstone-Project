using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    AudioSource m_explosionSource;

    void Awake()
    {
        m_explosionSource.Play();
    }
    
    void Update()
    {
        if (!m_explosionSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
