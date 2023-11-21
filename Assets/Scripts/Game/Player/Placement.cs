using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Placement : MonoBehaviour
{
    [SerializeField]
    Transform m_placementPoint;

    public GameObject placer;

    [SerializeField]
    SpriteRenderer m_placerSr;

    [SerializeField]
    SpriteRenderer m_placerMask;

    [SerializeField]
    List <PlaceableObject> m_placeables;

    int m_currentIdx =0;
    int m_curScroll =0;

    [SerializeField]
    PlayerInventory m_inventory;

    [SerializeField]
    PlayerStatus m_status;

    [SerializeField]
    Transform m_parent;

    const int SCROLL_DELTA =5;

    void Awake()
    {
        m_placerSr.sprite =m_placeables[0].sprite;
    }

    void HandleScroll()
    {
        if (m_placeables.Count >1)
        {
            m_curScroll += (int) Input.mouseScrollDelta.y;
            m_curScroll = m_curScroll % (SCROLL_DELTA *m_placeables.Count);
            if (m_curScroll<0)
            {
                m_curScroll =-m_curScroll;
            }
            m_currentIdx =(m_curScroll/SCROLL_DELTA);
        }
        m_placerSr.sprite =m_placeables[m_currentIdx].sprite;
    }

    void UpdatePlacement()
    {
        Vector3 worldTilePlacement =m_placementPoint.position;
        worldTilePlacement.x =(float)Mathf.Floor(worldTilePlacement.x) +placer.transform.localScale.x/2;
        worldTilePlacement.y =(float)Mathf.Ceil(worldTilePlacement.y) -placer.transform.localScale.y/2;

        Debug.DrawRay(gameObject.transform.position, m_placementPoint.position -gameObject.transform.position, Color.white, 0f, false);
        placer.transform.position =worldTilePlacement;
    }

    void FixedUpdate()
    {
        if (MenuManager.singleton!.isMovement
            && m_status.CanBuild()
            && placer.activeSelf)
        {

                        
            HandleScroll();
            UpdatePlacement();

            Collider2D collider =Physics2D.OverlapArea(new Vector2(placer.transform.position.x, placer.transform.position.y),
                new Vector2(placer.transform.position.x +1f, placer.transform.position.y-1f),
                1<<3);
            bool isPlaceable =collider==null;
            m_placerMask.color = isPlaceable ? new Color(0f, 0f, 1f, 0.34f) : new Color(1f, 0f, 0f, 0.34f);

            if (Input.GetButtonDown("Fire1")
                && m_inventory.money >= m_placeables[m_currentIdx].cost
                && isPlaceable)
            {
                 m_inventory.money -= m_placeables[m_currentIdx].cost;
                Instantiate(m_placeables[m_currentIdx].objectPrefab, placer.transform.position, Quaternion.identity, m_parent);
            }
        }
    }
}
