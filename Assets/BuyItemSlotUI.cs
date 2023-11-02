using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BuyItemSlotUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text m_name;

    [SerializeField]
    TMP_Text m_description;

    [SerializeField]
    TMP_Text m_cost;

    [SerializeField]
    BuyItemSlot m_itemSlot;

    void Start()
    {
        m_name.text =m_itemSlot.Name;
        m_description.text =m_itemSlot.description;
        m_cost.text = "$" +Convert.ToString(m_itemSlot.cost);
    }
}
