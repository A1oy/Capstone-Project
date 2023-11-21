using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerUI : MonoBehaviour
{
    Dictionary<InventoryItem, GameObject> inventoryToUIDict
        = new Dictionary<InventoryItem, GameObject>();

    [SerializeField]
    GameObject m_inventoryItemPrefab;

    public void UpdateUI(PlayerInventory playerInventory)
    {
        List<InventoryItem> items =new List<InventoryItem>();

        foreach (InventoryItem item in inventoryToUIDict.Keys)
        {
            if (playerInventory.itemSlots.Find(x=> x.item==item)==null)
            {
                Destroy(inventoryToUIDict[item]);
                items.Add(item);
            }
        }
        foreach (InventoryItem item in items)
        {
            inventoryToUIDict.Remove(item);
        }
        items.Clear();

        foreach (PlayerInventory.ItemSlot slot in playerInventory.itemSlots)
        {
            if (inventoryToUIDict.ContainsKey(slot.item))
            {
                inventoryToUIDict[slot.item].GetComponent<InventoryItemUI>()
                    .UpdateItem(slot.quantity);
            }
            else
            {
                items.Add(slot.item);
            }
        }

        foreach (InventoryItem item in items)
        {
            GameObject instance =Instantiate(m_inventoryItemPrefab,
                transform,
                true);

            instance.GetComponent<InventoryItemUI>()
                .SetItem(item.buyItem.sprite);
            inventoryToUIDict.Add(item, instance);
        }
    }
}
