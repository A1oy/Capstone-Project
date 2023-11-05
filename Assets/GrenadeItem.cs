using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : InventoryItem
{
    [SerializeField]
    GameObject m_grenadePrefab;

    [SerializeField]
    float grenadeForce;

    public override void OnUse(Transform firePoint, PlayerInventory inventory)
    {
        GameObject bullet = Instantiate(m_grenadePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * grenadeForce, ForceMode2D.Impulse);
    }
}
