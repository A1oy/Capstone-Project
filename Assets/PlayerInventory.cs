using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public class ItemSlot
    {
        public InventoryItem item;
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
    public int money;
    
    [System.NonSerialized]
    public int honey;

    [System.NonSerialized]
    public Weapon weapon = new Weapon();

    public List<ItemSlot> itemSlots =new List<ItemSlot>();
    int currentIdx =0;
    int m_curScroll =0;
    const int m_scrollPerItems =30;

    public void UseItem(Transform firePoint)
    {
        if (itemSlots.Count>0)
        {
            ItemSlot itemslot =itemSlots[currentIdx];
            itemslot.item.OnUse(firePoint, this);
            itemslot.quantity--;
            if (itemslot.quantity==0)
            {
                itemSlots.RemoveAt(currentIdx);
                currentIdx--;
                if (currentIdx <0)
                {
                    currentIdx =0;
                }
            }
        }
    }

    public void AddItem(InventoryItem item)
    {
        bool isAdded =false;
        for (int i=0;
            i<itemSlots.Count;
            i++)
        {
            if (itemSlots[i].item.buyItem == item.buyItem)
            {
                itemSlots[i].quantity++;
                isAdded =true;
            }
        }
        if (!isAdded)
        {
            ItemSlot newItem =new ItemSlot();
            newItem.quantity=1;
            newItem.item =item;
            itemSlots.Add(newItem);
        }
    }

    void Update()
    {
        if (itemSlots.Count >1
            &&MenuManager.singleton!.isMovement)
        {
            m_curScroll += (int) (0.1f *Input.mouseScrollDelta.y);
            if (m_curScroll <0)
            {
                m_curScroll += m_scrollPerItems *itemSlots.Count;
            }
            currentIdx =m_curScroll/m_scrollPerItems;
            if (currentIdx >= itemSlots.Count)
            {
                currentIdx = currentIdx%itemSlots.Count;
            }
        }
    }
}
