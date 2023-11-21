using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyMenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject buyContainer;

    [SerializeField]
    AudioSource m_openingSource;

    [SerializeField]
    AudioSource m_closingSource;

    void OnEnable()
    {
        m_openingSource.Play();
        MenuManager.singleton!.isMovement =false;
        buyContainer.SetActive(true);
    }
    
    void OnDisable()
    {
        m_closingSource.Play();
        MenuManager.singleton!.isMovement =true;
        buyContainer.SetActive(false);
    }
}
