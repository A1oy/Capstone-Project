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
    PlayerInventory m_inventory;

    [SerializeField]
    TMP_Text moneyAmount;

    [SerializeField]
    Slider honeySlider;

    [SerializeField]
    TMP_Text honeyAmount;

    [SerializeField]
    TMP_Text playerScore;

    void Awake()
    {
        gameDay.text ="Day 1";
    }

    void HandlePlayerUI()
    {
        honeySlider.value =m_inventory.GetHoney();
        honeyAmount.text =$"{m_inventory.GetHoney()}%";
        moneyAmount.text =Convert.ToString(m_inventory.GetMoney());
        playerScore.text =m_inventory.GetScore().ToString("D8");
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
        HandlePlayerUI();
        gameTime.text =m_gameManager.GetTimeString();
    }
}
