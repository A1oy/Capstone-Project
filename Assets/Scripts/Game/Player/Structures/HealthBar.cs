using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    GameObject m_intermBar;

    [SerializeField]
    Slider m_slider;

    [SerializeField]
    Health m_health;

    void OnInteract(GameObject player)
    {
        Debug.Log("LOL");
        m_intermBar.SetActive(true);
    }
    
    void OnLeaveInteract()
    {
        m_intermBar.SetActive(false);
    }

     void FixedUpdate()
    {
        m_slider.value = (float)m_health.GetCurrentHealth()/m_health.GetMaxHealth();
    }
}
