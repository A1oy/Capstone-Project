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
    AudioClip openingClip;

    [SerializeField]
    AudioClip closingClip;

    void OnEnable()
    {
        MenuManager.singleton!.isMovement =false;
        buyContainer.SetActive(true);
        AudioManager.instance.PlaySoundEffect(openingClip);
    }
    
    void OnDisable()
    {
        MenuManager.singleton!.isMovement =true;
        buyContainer.SetActive(false);
        AudioManager.instance.PlaySoundEffect(closingClip);
    }
}
