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

    public void UpdateHoney(int value)
    {
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
        Debug.Log(rotation.eulerAngles);
        playerRadarArrow.rotation =rotation;
    }
}
