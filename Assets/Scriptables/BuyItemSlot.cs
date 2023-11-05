using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemSlot : MonoBehaviour
{
    public Sprite sprite;
    public string Name;
    public string description;
    public int cost;

}

public abstract class InventoryItem : MonoBehaviour
{
    public BuyItemSlot buyItem;

    public abstract void OnUse(Transform transform, PlayerInventory inventory);
}