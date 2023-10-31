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

    int currentLevel=0;

    void Start()
    {
        m_name.text =m_upgradeSlot.Name;
        if (m_upgradeSlot.Sprite)
        {
            m_icon.sprite =m_upgradeSlot.Sprite;
        }
        m_description.text =m_upgradeSlot.Desc;
        m_cost.text =Convert.ToString(m_upgradeSlot.GetMoneyReq(currentLevel));
    }

    public void Upgrade(int money)
    {
        if (money < m_upgradeSlot.GetMoneyReq(currentLevel))
        {
            return;
        }
        money -= m_upgradeSlot.GetMoneyReq(currentLevel);
    }
}
