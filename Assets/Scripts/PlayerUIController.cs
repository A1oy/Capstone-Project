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

    [Header("Health UI")]
    [SerializeField]
    Slider playerHealth;

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
        int value =GameObject.Find("Player")
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
        playerHealth.value =health.GetCurrentHealth()/(float)health.GetMaxHealth();
    }

    // Hive related functions

    public void StartHoneyCollecting()
    {
        UpdateCollecting(0f);
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
