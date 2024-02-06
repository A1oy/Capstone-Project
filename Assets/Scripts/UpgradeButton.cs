using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    [SerializeField]
    UpgradeData data;

    [SerializeField]
    TMP_Text cost;

    [SerializeField]
    GameObject description;

    void Awake()
    {
        if (data ==null)
        {
            cost.text ="0";
        }
        else
        {
            cost.text =Convert.ToString(data.honeyNeeded);
        }
    }

    public void OnClick()
    {
        if (GameObject.Find("Player")
            .GetComponent<PlayerHoney>()
            .Purchase(data))
        {
            UpgradeUIController uiController =GameObject.Find("UpgradeUI")
                .GetComponent<UpgradeUIController>();
            uiController.UpdateHoney();
            for (int i=0; i< transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).TryGetComponent<Button>(out Button button))
                {
                    button.interactable =false;
                }
            }
            for (int i=0; i<transform.childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent<Button>(out Button button))
                {
                    button.interactable =true;
                }
            }
            GameObject.Find("Player")
                .GetComponent<PlayerShooting>()
                .SetUpgrade(data);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter ==gameObject)
        {
            description.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.SetActive(false);
    }
}
