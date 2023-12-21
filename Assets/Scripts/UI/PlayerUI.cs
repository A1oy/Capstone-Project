using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    GameUI m_gameManager;

    [SerializeField]
    TMP_Text gameDay;
    
    [SerializeField]
    TMP_Text gameTime;

    [SerializeField]
    Slider honeySlider;

    void Awake()
    {
        gameDay.text ="Day 1";
    }


    void OnDaylightChange()
    {
        if (m_gameManager.IsDayTime())
        {
            gameDay.text = $"Day {m_gameManager.GetDay()}";
        }
    }
    void FixedUpdate()
    {
        gameTime.text =m_gameManager.GetTimeString();
    }
}
