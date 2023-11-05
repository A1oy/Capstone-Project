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

    public float value { set { m_slider.value =value;}}


    void OnInteract(GameObject player)
    {
        m_intermBar.SetActive(true);
    }
    
    void OnLeaveInteract()
    {
        m_intermBar.SetActive(false);
    }
    
    void OnInteracting()
    {
        
    }

    void Update()
    {
        if (GameUI.isDaytime == !interactable.isEnabled)
        {
            interactable.isEnabled =GameUI.isDaytime;
        }
    }
}
