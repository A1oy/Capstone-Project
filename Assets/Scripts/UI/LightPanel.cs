using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;   

public class LightPanel : MonoBehaviour
{
    [SerializeField]
    GameObject m_buyMenuManager;

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

    [SerializeField]
    PlayerShooting m_shooting;

    [Header("Base Honey Production")]
    [SerializeField]
    HoneyProduction m_production;

    [SerializeField]
    AudioSource m_purchasingSource;

    const int m_moneyMul=1;

    void OnEnable()
    {
        Weapon weapon =m_shooting.weapon;

        m_ammoSlot.lvl =weapon.m_ammoCapacityLvl;
        m_firerateSlot.lvl =weapon.m_fireSpeedLvl;
        m_reloadSlot.lvl =weapon.m_reloadSpeedLvl;
        m_damageSlot.lvl =weapon.m_damageLvl;

        m_money.text =Convert.ToString(m_inventory.GetMoney());
        
        m_productionSlot.lvl =m_production.honeyProductionLvl;
        m_honeyJarSlider.value =m_inventory.GetHoney();

        m_honeyPercent.text = $"{m_inventory.GetHoney()}%";
        m_sellHoneyText.text = "Sell for $0";
        ((Selectable)m_sellHoneyButton).interactable =false;

    }

    void Purchase()
    {
        m_money.text =Convert.ToString(m_inventory.GetMoney());
        m_purchasingSource.Play();
    }

    public void OnAmmo()
    {
        if (m_ammoSlot.Upgrade(m_inventory))
        {
            Purchase();
            m_shooting.weapon.m_ammoCapacityLvl++;
        }
    }

    public void OnFirerate()
    {
        if (m_firerateSlot.Upgrade(m_inventory))
        {
            Purchase();
            m_shooting.weapon.m_fireSpeedLvl++;
        }
    }

    public void OnReload()
    {
        if (m_reloadSlot.Upgrade(m_inventory))
        {
            Purchase();
            m_shooting.weapon.m_reloadSpeedLvl++;
        }
    }

    public void OnDamage()
    {
        if (m_damageSlot.Upgrade(m_inventory))
        {
            Purchase();
            m_shooting.weapon.m_damageLvl++;
        }
    }
    
    public void OnProduction()
    {
        if (m_productionSlot.Upgrade(m_inventory))
        {
            Purchase();
            m_production.honeyProductionLvl++;
        }
    }

    public void OnSlider()
    {
        if (m_inventory.GetHoney() < m_honeyJarSlider.value)
        {
            m_honeyJarSlider.value =m_inventory.GetHoney();
        }
        if (m_honeyJarSlider.value == m_inventory.GetHoney()
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
            int diff =m_inventory.GetHoney() -(int)m_honeyJarSlider.value;
            m_sellHoneyText.text = $"Sell for ${m_moneyMul * diff}";
        }
    }

    public void OnSellHoney()
    {
        int diff =m_inventory.GetHoney() -(int)m_honeyJarSlider.value;
        if (diff>0)
        {
            m_inventory.AddHoney(-diff);
            m_honeyJarSlider.value =(float)m_inventory.GetHoney();
            ((Selectable)m_sellHoneyButton).interactable =false;
            m_sellHoneyText.text = "Sell for $0";
            m_honeyPercent.text = $"{m_inventory.GetHoney()}%";

            int moneyDiff =m_moneyMul *diff;
            m_inventory.AddMoney(moneyDiff);
            Purchase();
        }
    }

    public void OnBuyItem(InventoryItem item)
    {
        if (m_inventory.GetMoney() >= item.buyItem.cost)
        {
            m_inventory.AddMoney(-item.buyItem.cost);
            Purchase();
            m_inventory.AddItem(item);
        }
    }

    public void Exit()
    {
        m_shooting.weapon.Upgrade();
        m_production.Upgrade();
        m_buyMenuManager.SetActive(false);
    }
}
