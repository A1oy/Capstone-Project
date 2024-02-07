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
    int amt; 

    [SerializeField]
    TMP_Text cost;

    [SerializeField]
    GameObject description;

    void Awake()
    {
        cost.text =Convert.ToString(amt);
    }

    public void OnClick()
    {
        if (GameObject.Find("Player")
            .GetComponent<PlayerHoney>()
            .Purchase(amt))
        {
            UpgradeUIController uiController =GameObject.Find("UpgradeUI")
                .GetComponent<UpgradeUIController>();
            uiController.UpdateHoney();
            /*for (int i=0; i< transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).TryGetComponent<Button>(out Button button))
                {
                    button.interactable =false;
                }
            }
            */
            gameObject.GetComponent<Button>().interactable =false;
            for (int i=0; i<transform.childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent<Button>(out Button button))
                {
                    button.interactable =true;
                }
            }
            gameObject.SendMessage("OnUpgrade", SendMessageOptions.RequireReceiver);
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
