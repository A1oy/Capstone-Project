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

    const int m_moneyMul=1;

    [SerializeField]
    AudioClip m_purchasingClip;


    void OnEnable()
    {
        Weapon weapon =m_shooting.weapon;

        m_ammoSlot.lvl =weapon.m_ammoCapacityLvl;
        m_firerateSlot.lvl =weapon.m_fireSpeedLvl;
        m_reloadSlot.lvl =weapon.m_reloadSpeedLvl;
        m_damageSlot.lvl =weapon.m_damageLvl;

        m_money.text =Convert.ToString(m_inventory.money);
        
        m_productionSlot.lvl =m_production.honeyProductionLvl;
        m_honeyJarSlider.value =m_inventory.honey;

        m_honeyPercent.text = $"{m_inventory.honey}%";
        m_sellHoneyText.text = "Sell for $0";
        ((Selectable)m_sellHoneyButton).interactable =false;

    }

    public void OnAmmo()
    {
        if (m_ammoSlot.Upgrade(m_inventory))
        {
            AudioManager.instance.PlaySoundEffect(m_purchasingClip);
            m_money.text =Convert.ToString(m_inventory.money);
            m_shooting.weapon.m_ammoCapacityLvl++;
        }
    }

    public void OnFirerate()
    {
        if (m_firerateSlot.Upgrade(m_inventory))
        {
            AudioManager.instance.PlaySoundEffect(m_purchasingClip);
            m_money.text =Convert.ToString(m_inventory.money);
            m_shooting.weapon.m_fireSpeedLvl++;
        }
    }

    public void OnReload()
    {
        if (m_reloadSlot.Upgrade(m_inventory))
        {
            AudioManager.instance.PlaySoundEffect(m_purchasingClip);
            m_money.text =Convert.ToString(m_inventory.money);
            m_shooting.weapon.m_reloadSpeedLvl++;
        }
    }

    public void OnDamage()
    {
        if (m_damageSlot.Upgrade(m_inventory))
        {
            AudioManager.instance.PlaySoundEffect(m_purchasingClip);
            m_money.text =Convert.ToString(m_inventory.money);
            m_shooting.weapon.m_damageLvl++;
        }
    }
    
    public void OnProduction()
    {
        if (m_productionSlot.Upgrade(m_inventory))
        {
            AudioManager.instance.PlaySoundEffect(m_purchasingClip);
            m_money.text =Convert.ToString(m_inventory.money);
            m_production.honeyProductionLvl++;
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
            AudioManager.instance.PlaySoundEffect(m_purchasingClip);
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
        if (m_inventory.money >= item.buyItem.cost)
        {
            AudioManager.instance.PlaySoundEffect(m_purchasingClip);
            m_inventory.money -= item.buyItem.cost;
            m_money.text =Convert.ToString(m_inventory.money);
            m_inventory.AddItem(item);
        }
    }

    public void Exit()
    {
        m_shooting.weapon.Upgrade();
        m_buyMenuManager.SetActive(false);
    }
}
