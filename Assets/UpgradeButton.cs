using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{ 
    [SerializeField]
    UpgradeData data;

    public void OnClick()
    {
        for (int i=0; i< transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<Button>()
                .interactable = false;
        }
        for (int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Button>()
                .interactable =true;
        }
        NetworkManager.GetLocalPlayer()
            .GetComponent<PlayerShooting>()
            .SetUpgrade(data);

    }
}
