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

    [SerializeField]
    Transform firePoint;

    int m_money;
    
    int m_honey;

    [SerializeField]
    float m_honeyForce;

    [SerializeField]
    GameObject m_honeyPrefab;

    [SerializeField]
    PlayerStatus m_status;

    [SerializeField]
    ItemContainerUI m_itemContainer;

    [SerializeField]
    ItemContainerUI m_itemContainer2;

    int m_score;

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
            m_itemContainer.UpdateUI(this);
            m_itemContainer2.UpdateUI(this);
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
        m_itemContainer.UpdateUI(this);
        m_itemContainer2.UpdateUI(this);
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

        if (Input.GetButtonDown("Fire2")
            && !m_status.CanBuild())
        {
            UseItem(firePoint);
        }
        else if (Input.GetButtonDown("Fire3")
            && !m_status.CanBuild())
        {
            DeployHoney();
        }
    }

    void DeployHoney()
    {
        if (m_honey >=5)
        {
            GameObject bullet = Instantiate(m_honeyPrefab, firePoint.position, firePoint.rotation);
            m_honey -=5;
        }
        
    }

    public int GetMoney()
    {
        return m_money; 
    }

    public void AddMoney(int money)
    {
        if (m_money + money >= 0)
        {
            m_money += money; 
        }
    }
    
    public void AddHoney(int honey)
    {
        if (m_honey + honey <= 100)
        {
            m_honey += honey; 
        }
        else
        {
            m_honey = 100; 
        }
    }

    public int GetHoney()
    {
        return m_honey; 
    }

    public void AddScore(int scoreAdded)
    {
        m_score +=scoreAdded;
    }

    public int GetScore()
    {
        return m_score;
    }
}
