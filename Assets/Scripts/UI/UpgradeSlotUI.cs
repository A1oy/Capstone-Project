using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using  UnityEngine.UI;
using System;

public class UpgradeSlotUI : MonoBehaviour
{
    [SerializeField]
    UpgradeSlot m_upgradeSlot;

    [SerializeField]
    TMP_Text m_name;

    [SerializeField]
    Image m_icon;

    [SerializeField]
    TMP_Text m_description;

    [SerializeField]
    TMP_Text m_cost;

    [SerializeField]
    Slider m_slider;
    
    [SerializeField]
    int m_currentLevel=0;

    public int lvl
    {
        set 
        {
            m_currentLevel =value;
            m_slider.value =value *0.2f;
        }

        get { return m_currentLevel; }
    }

    void Start()
    {
        m_name.text =m_upgradeSlot.Name;
        if (m_upgradeSlot.sprite)
        {
            m_icon.sprite =m_upgradeSlot.sprite;
        }
        m_description.text =m_upgradeSlot.description[m_currentLevel];
        m_cost.text = "$" +Convert.ToString(m_upgradeSlot.moneyReq[m_currentLevel]);
    }

    public bool Upgrade(PlayerInventory inventory)
    {
        if (m_currentLevel<5
            && inventory.GetMoney() < m_upgradeSlot.moneyReq[m_currentLevel])
        {
            return false;
        }
        inventory.AddMoney(-m_upgradeSlot.moneyReq[m_currentLevel]);
        m_cost.text ="$" +Convert.ToString(m_upgradeSlot.moneyReq[m_currentLevel]);
        lvl++;
        return true;
    }
}
