using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    GameObject intermBar;

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
}
