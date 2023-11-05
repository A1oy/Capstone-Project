using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    GameObject intermBar;

    [SerializeField]
    Interactable interactable;

    void OnInteract(GameObject player)
    {
        intermBar.SetActive(true);
    }
    
    void OnLeaveInteract()
    {
        intermBar.SetActive(false);
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
