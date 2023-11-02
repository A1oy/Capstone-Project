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
    Image m_sellHoneyButton;

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

    void OnEnable()
    {
        PlayerInventory.Weapon weapon =m_inventory.weapon;

        m_ammoSlot.lvl =weapon.m_ammoCapacityLvl;
        m_firerateSlot.lvl =weapon.m_fireSpeedLvl;
        m_reloadSlot.lvl =weapon.m_reloadSpeedLvl;
        m_damageSlot.lvl =weapon.m_damageLvl;

        m_money.text =Convert.ToString(m_inventory.money);
        
        m_productionSlot.lvl =m_base.honeyProductionLvl;


        m_honeyJarSlider.value =m_inventory.honey /100f;
        m_honeyPercent.text = $"{m_inventory.honey}%";
        m_sellHoneyText.text = "Sell for $0";
        m_sellHoneyButton.color =new Color(0.5f, 0.5f, 0.5f, 1.0f);
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
}
