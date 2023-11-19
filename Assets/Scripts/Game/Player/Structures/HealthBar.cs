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
    Interactable interactable;

    [SerializeField]
    Health m_health;

    void OnInteract(GameObject player)
    {
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

    void OnDaylightChange(bool isDayTime)
    {
        interactable.isEnabled = isDayTime;
    }
}
