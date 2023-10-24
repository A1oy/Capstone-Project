using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placement : MonoBehaviour
{
    public Transform placementPoint;
    public GameObject placer;
    public GameObject placerMask;
    public List <PlaceableObject> placeables;
    
    int currentIdx =0;
    int curScroll =0;
    const int scrollPerPlaceables =30;

    void Awake()
    {
        placer.GetComponent<SpriteRenderer>().sprite =placeables[0].sprite;
    }

    void Update()
    {
        if (MenuManager.singleton!.isMovement
            && placer.activeSelf)
        {   
            Vector3 worldTilePlacement =placementPoint.position;
            worldTilePlacement.x =(float)Mathf.Floor(worldTilePlacement.x) +placer.transform.localScale.x/2;
            worldTilePlacement.y =(float)Mathf.Ceil(worldTilePlacement.y) -placer.transform.localScale.y/2;

            Debug.DrawRay(gameObject.transform.position, placementPoint.position -gameObject.transform.position, Color.white, 0f, false);
            placer.transform.position =worldTilePlacement;

            if (placeables.Count >1)
            {
                curScroll += (int) (0.1f *Input.mouseScrollDelta.y);
                if (curScroll <0)
                {
                    curScroll += scrollPerPlaceables *placeables.Count;
                }
                currentIdx =curScroll/scrollPerPlaceables;
            }
            placer.GetComponent<SpriteRenderer>().sprite =placeables[currentIdx].sprite;

            bool isPlaceable =Physics2D.OverlapArea(new Vector2(worldTilePlacement.x, worldTilePlacement.y), Vector2.one, 1<<3)==null;
            if (isPlaceable)
            {
                placerMask.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 0.34f);
            }
            else
            {
                placerMask.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.34f);
            }

            if (Input.GetButtonDown("Fire1")
                && GetComponent<Player>().money >= placeables[currentIdx].cost
                && isPlaceable)
            {
                GetComponent<Player>().money -= placeables[currentIdx].cost;
                Instantiate(placeables[currentIdx].objectPrefab, placer.transform.position, Quaternion.identity);
            }
        }
    }
}
