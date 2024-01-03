using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [Header("Eating UI")]
    [SerializeField]
    Slider progressBar;

    [Header("Honey UI")]
    [SerializeField]
    Slider honeyJar;
    [SerializeField]
    TMP_Text honey;

    [Header("Day Time UI")]
    [SerializeField]
    TMP_Text day;
    [SerializeField]
    TMP_Text time;

    [Header("Health UI")]
    [SerializeField]
    Image healthWarning;
    [SerializeField]
    float redThreshold;

    [Header("Radar UI")]
    [SerializeField]
    Transform playerRadarArrow;

    [Header("Battery UI")]
    [SerializeField]
    Slider[] sliders;

    [SerializeField]
    GameObject insertBatteryButton;

    [SerializeField]
    GameObject getBatteryButton;

    [Header("Hive UI")]
    [SerializeField]
    Slider collectProgressBar;

    [SerializeField]
    GameObject hiveActiveButton;

    int curIndex =0;

    // Eating related functions

    public void StartEating()
    {
        progressBar.gameObject.SetActive(true);
    }

    public void StopEating()
    {
        progressBar.gameObject.SetActive(false);
        progressBar.value =0;
    }

    public void UpdateEating(float value)
    {
        progressBar.value = value;
    }

    // Honey related functions

    public void UpdateHoney()
    {
        int value =NetworkManager0.GetLocalPlayer()
            .GetComponent<PlayerHoney>()
            .GetHoney();
        honey.text =Convert.ToString(value);
        honeyJar.value = value;
    }

    //  Day-Time related functions

    public void UpdateDay(string day)
    {
        this.day.text =day;
    }
    
    public void UpdateTime(string time)
    {
        this.time.text =time;
    }

    // Health related functions

    public void UpdateHealth(Health health)
    {
        float alpha = 1f - ((float)health.GetCurrentHealth()/health.GetMaxHealth());
        alpha =Mathf.Clamp(alpha, 0f, redThreshold);
        healthWarning.color = new Color(1f, 0f, 0f, alpha);
    }

    // Radar related functions
    public void UpdateRadarRotation(Quaternion rotation)
    {
        playerRadarArrow.rotation =rotation;
    }

    // Battery related functions

    public void RemoveEmptyBattery()
    {
        for (int i=0; i<3; i++)
        {
            if (sliders[i].value ==0f && sliders[i].gameObject.transform.parent.gameObject.activeInHierarchy)
            {
                sliders[i].gameObject.transform.parent.gameObject.SetActive(false);
                break;
            }
        }
    }

    public void AddFilledBattery()
    {
        for (int i=0; i<3; i++)
        {
            if (!sliders[i].gameObject.transform.parent.gameObject.activeInHierarchy)
            {
                sliders[i].gameObject.transform.parent.gameObject.SetActive(true);
                sliders[i].value =1f;
                sliders[i].gameObject.transform.parent.SetAsFirstSibling();
                break;
            }
        }
    }

    public void UpdateActiveBattery(float value)
    {
        sliders[curIndex].value =value;
        if (value ==0f)
        {
            curIndex =0;
            for (int i=0; i<3; i++)
            {
                if (sliders[i].value >0f && i!=curIndex)
                {
                    curIndex =i;
                    break;
                }
            }
        }
    }

    public bool InsertBatteryEnabled()
    {
        return insertBatteryButton.activeInHierarchy;
    }
    
    public bool GetBatteryEnabled()
    {
        return getBatteryButton.activeInHierarchy;
    }

    public void EnableInsertBattery()
    {
        insertBatteryButton.SetActive(true);
    }

    public void EnableGetBattery()
    {
        getBatteryButton.SetActive(true);
    }

    public void DisableInsertBattery()
    {
        insertBatteryButton.SetActive(false);
    }

    public void DisableGetBattery()
    {
        getBatteryButton.SetActive(false);
    }

    // Hive related functions

    public void StartHoneyCollecting()
    {
        collectProgressBar.gameObject.SetActive(true);
    }

    public bool IsCollecting()
    {
        return collectProgressBar.gameObject.activeInHierarchy;
    }

    public void StopHoneyCollecting()
    {
        collectProgressBar.gameObject.SetActive(false);
    }

    public void UpdateCollecting(float value)
    {
        collectProgressBar.value =value;
    }

    public void EnableHiveActivate()
    {
        hiveActiveButton.SetActive(true);
    }

    public bool IsHiveActivateEnabled()
    {
        return hiveActiveButton.activeInHierarchy;
    }

    public void DisableHiveActivate()
    {
        hiveActiveButton.SetActive(false);
    }
}
