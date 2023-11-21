using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 

//This will 
public class ConsumeHoney : MonoBehaviour
{
    [SerializeField]
    Health playerHealth;

    [SerializeField]
    PlayerInventory inventory;  //Get the inventory of the user

    [SerializeField]
    public Slider s;

    [SerializeField]
    float eatingTime;

    [SerializeField]
    int honeyDeducted = 5;

    [SerializeField]
    int healthHealed = 2;

    [SerializeField]
    GameObject progressBar;

    [SerializeField]
    AudioSource m_glupingSource;

    bool isDrinking = false;

    float timePassedSincePressed = 0f;

    bool EnoughHoney() => inventory.honey >= honeyDeducted;

    void ExecuteProgressBar()
    {
        s.value = timePassedSincePressed / eatingTime;
        if (s.value >= 1f)
        {
            isDrinking = false;
            progressBar.SetActive(false);
            timePassedSincePressed = 0f;


            inventory.honey -= honeyDeducted;
            m_glupingSource.Play();
            playerHealth.Heal(healthHealed);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!isDrinking && EnoughHoney())
            {
                progressBar.SetActive(true);
                isDrinking = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            isDrinking = false;
            progressBar.SetActive(false);
            s.value = 0f;
            timePassedSincePressed = 0f;
        }

        if (isDrinking)
        {
            timePassedSincePressed += Time.deltaTime;
            ExecuteProgressBar();
        }
    }


}
