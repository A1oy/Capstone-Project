using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    const int SCROLL_DELTA =30;

    [SerializeField]
    PlayerInventory m_inventory;

    [SerializeField]
    PlayerStatus m_status;

    void Awake()
    {
        m_placerSr.sprite =m_placeables[0].sprite;
    }

    void HandleScroll()
    {
        if (m_placeables.Count >1)
        {
            m_curScroll += (int) (0.1f *Input.mouseScrollDelta.y);
            if (m_curScroll <0)
            {
                m_curScroll += SCROLL_DELTA *m_placeables.Count;
            }
            m_currentIdx =m_curScroll/SCROLL_DELTA;
            if (m_currentIdx >= m_placeables.Count)
            {
                m_currentIdx = m_currentIdx %m_placeables.Count;
            }
        }
        m_placerSr.sprite =m_placeables[m_currentIdx].sprite;
    }

    void Update()
    {
        if (MenuManager.singleton!.isMovement
            && m_status.isBuildMode
            && placer.activeSelf)
        {   
            Vector3 worldTilePlacement =m_placementPoint.position;
            worldTilePlacement.x =(float)Mathf.Floor(worldTilePlacement.x) +placer.transform.localScale.x/2;
            worldTilePlacement.y =(float)Mathf.Ceil(worldTilePlacement.y) -placer.transform.localScale.y/2;

            Debug.DrawRay(gameObject.transform.position, m_placementPoint.position -gameObject.transform.position, Color.white, 0f, false);
            placer.transform.position =worldTilePlacement;

            HandleScroll();

            bool isPlaceable =Physics2D.OverlapArea(new Vector2(worldTilePlacement.x, worldTilePlacement.y), Vector2.one, 1<<3)==null;
            m_placerMask.color = isPlaceable ? new Color(0f, 0f, 1f, 0.34f) : new Color(1f, 0f, 0f, 0.34f);

            if (Input.GetButtonDown("Fire1")
                && m_inventory.money >= m_placeables[m_currentIdx].cost
                && isPlaceable)
            {
                 m_inventory.money -= m_placeables[m_currentIdx].cost;
                Instantiate(m_placeables[m_currentIdx].objectPrefab, placer.transform.position, Quaternion.identity);
            }
        }
    }
}
