using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject buyContainer;

    void OnEnable()
    {
        MenuManager.singleton!.isMovement =false;
        buyContainer.SetActive(true);
    }
    
    void OnDisable()
    {
        MenuManager.singleton!.isMovement =true;
        buyContainer.SetActive(false);
    }
}
