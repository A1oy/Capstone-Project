using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField]
    Image m_item;

    [SerializeField]
    TMP_Text m_count;

    public void UpdateItem(int quantity)
    {
        m_count.text =$"x{quantity}";
    }

    public void SetItem(Sprite sprite)
    {
        m_item.sprite =sprite;
        m_item.preserveAspect =true;
        m_count.text ="x1";
    }
}
