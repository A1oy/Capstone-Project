using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;   

public class LightPanel : MonoBehaviour
{
    [SerializeField]
    UpgradeSlotUI m_ammoSlot;

    [SerializeField]
    UpgradeSlotUI m_firerateSlot;

    [SerializeField]
    UpgradeSlotUI m_reloadSlot;

    [SerializeField]
    UpgradeSlotUI m_damageSlot;

    [SerializeField]
    UpgradeSlotUI m_productionSlot;

    [SerializeField]
    List<BuyItemSlotUI> m_itemSlotUiElements;

    [SerializeField]
    TMP_Text m_money;
    
    [Header("Honey Settings")]
    [SerializeField]
    Button m_sellHoneyButton;

    [SerializeField]
    TMP_Text m_sellHoneyText;

    [SerializeField]
    TMP_Text m_honeyPercent;

    [SerializeField]
    Slider m_honeyJarSlider;

    [Header("Player")]
    [SerializeField]
    PlayerInventory m_inventory;

    [Header("Base")]
    [SerializeField]
    Base m_base;

    const int m_moneyMul=1;


    void OnEnable()
    {
        PlayerInventory.Weapon weapon =m_inventory.weapon;

        m_ammoSlot.lvl =weapon.m_ammoCapacityLvl;
        m_firerateSlot.lvl =weapon.m_fireSpeedLvl;
        m_reloadSlot.lvl =weapon.m_reloadSpeedLvl;
        m_damageSlot.lvl =weapon.m_damageLvl;

        m_money.text =Convert.ToString(m_inventory.money);
        
        m_productionSlot.lvl =m_base.honeyProductionLvl;
        m_honeyJarSlider.value =m_inventory.honey;

        m_honeyPercent.text = $"{m_inventory.honey}%";
        m_sellHoneyText.text = "Sell for $0";
        ((Selectable)m_sellHoneyButton).interactable =false;

    }

    public void OnAmmo()
    {
        if (m_ammoSlot.Upgrade(m_inventory))
        {
            m_money.text =Convert.ToString(m_inventory.money);
            m_inventory.weapon.m_ammoCapacityLvl++;
            m_inventory.weapon.m_ammoCapacity++;
        }
    }

    public void OnFirerate()
    {
        if (m_firerateSlot.Upgrade(m_inventory))
        {
            m_money.text =Convert.ToString(m_inventory.money);
            m_inventory.weapon.m_fireSpeedLvl++;
            m_inventory.weapon.m_fireSpeed++;
        }
    }

    public void OnReload()
    {
        if (m_reloadSlot.Upgrade(m_inventory))
        {
            m_money.text =Convert.ToString(m_inventory.money);
            m_inventory.weapon.m_reloadSpeedLvl++;
            m_inventory.weapon.m_reloadSpeed++;
        }
    }

    public void OnDamage()
    {
        if (m_damageSlot.Upgrade(m_inventory))
        {
            m_money.text =Convert.ToString(m_inventory.money);
            m_inventory.weapon.m_damageLvl++;
            m_inventory.weapon.m_damage++;
        }
    }
    
    public void OnProduction()
    {
        if (m_productionSlot.Upgrade(m_inventory))
        {
            m_money.text =Convert.ToString(m_inventory.money);
            m_base.honeyProductionLvl++;
            m_base.honeyEachRound++;
        }
    }

    public void OnSlider()
    {
        if (m_inventory.honey < m_honeyJarSlider.value)
        {
            m_honeyJarSlider.value =m_inventory.honey;
        }
        if (m_honeyJarSlider.value ==m_inventory.honey
            && ((Selectable)m_sellHoneyButton).interactable)
        {
            ((Selectable)m_sellHoneyButton).interactable =false;
            m_sellHoneyText.text = "Sell for $0";
        }
        else if (!((Selectable)m_sellHoneyButton).interactable)
        {
            ((Selectable)m_sellHoneyButton).interactable =true;
        }
        if (((Selectable)m_sellHoneyButton).interactable)
        {
            int diff =m_inventory.honey -(int)m_honeyJarSlider.value;
            m_sellHoneyText.text = $"Sell for ${m_moneyMul * diff}";
        }
    }

    public void OnSellHoney()
    {
        int diff =m_inventory.honey -(int)m_honeyJarSlider.value;
        if (diff>0)
        {
            m_inventory.honey -=diff;
            m_honeyJarSlider.value =(float)m_inventory.honey;
            ((Selectable)m_sellHoneyButton).interactable =false;
            m_sellHoneyText.text = "Sell for $0";
            m_honeyPercent.text = $"{m_inventory.honey}%";

            int moneyDiff =m_moneyMul *diff;
            m_inventory.money +=moneyDiff;
            m_money.text =Convert.ToString(m_inventory.money);
        }
    }

    public void OnBuyItem(InventoryItem item)
    {
        Debug.Log("Buying");
        if (m_inventory.money >= item.buyItem.cost)
        {
            m_inventory.money -= item.buyItem.cost;
            m_money.text =Convert.ToString(m_inventory.money);
            m_inventory.AddItem(item);
        }
    }
}
