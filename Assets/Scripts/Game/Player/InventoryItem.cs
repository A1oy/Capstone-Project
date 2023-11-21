using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : MonoBehaviour
{
    public BuyItemSlot buyItem;

    public abstract void OnUse(Transform transform, PlayerInventory inventory);
}