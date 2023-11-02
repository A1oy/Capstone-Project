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

    int m_currentLevel=0;

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

    public void Upgrade(int money)
    {
        if (money < m_upgradeSlot.moneyReq[m_currentLevel])
        {
            return;
        }
        money -= m_upgradeSlot.moneyReq[m_currentLevel];
        m_currentLevel++;
        m_cost.text ="$" +Convert.ToString(m_upgradeSlot.moneyReq[m_currentLevel]);
    }
}
