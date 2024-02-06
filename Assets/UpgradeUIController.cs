using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUIController : MonoBehaviour
{
    [SerializeField]
    TMP_Text honey;

    [SerializeField]
    Slider slider;

    public void UpdateHoney()
    {
        int value =GameObject.Find("Player")
            .GetComponent<PlayerHoney>()
            .GetHoney();
        honey.text = Convert.ToString(value);
        slider.value =value;
    }
}
