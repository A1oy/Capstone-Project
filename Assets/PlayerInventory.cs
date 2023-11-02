using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public class ItemSlot
    {
        public BuyItemSlot item;
        public int quantity;
    }

    public class Weapon
    {
        Sprite sprite;

        public int m_fireSpeed;
        public int m_reloadSpeed;
        public int m_ammoCapacity;
        public int m_ammo;
        public int m_damage;

        public int m_fireSpeedLvl;
        public int m_reloadSpeedLvl;
        public int m_ammoCapacityLvl;
        public int m_damageLvl;
    };
    
    [System.NonSerialized]
    public int money =10;
    
    [System.NonSerialized]
    public int honey =20;

    [System.NonSerialized]
    public List<ItemSlot> itemSlots;
    
    [System.NonSerialized]
    public Weapon weapon = new Weapon();
}
