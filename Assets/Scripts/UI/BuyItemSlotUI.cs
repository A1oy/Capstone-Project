using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    Image m_item;

    [SerializeField]
    InventoryItem m_itemSlot;

    void Awake()
    {
        m_name.text =m_itemSlot.buyItem.Name;
        m_description.text =m_itemSlot.buyItem.description;
        m_cost.text = "$" +Convert.ToString(m_itemSlot.buyItem.cost);
        m_item.sprite =m_itemSlot.buyItem.sprite;
        m_item.preserveAspect= true;
    }
}
