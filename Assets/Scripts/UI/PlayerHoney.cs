using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHoney : MonoBehaviour
{
    enum CosumeHoneyState
    {
        Nothing,
        Eating,
        Cooldown
    };

    [SerializeField]
    Health playerHealth;

    PlayerUIController uiController;

    int honey =10;

    [SerializeField]
    float eatingTime;

    [SerializeField]
    int honeyDeducted = 5;

    [SerializeField]
    int healthHealed = 2;

    [SerializeField]
    float cooldown =1.2f;

    [SerializeField]
    AudioSource glupingSource;

    CosumeHoneyState state =CosumeHoneyState.Nothing;

    float timePassed = 0f;

    bool EnoughHoney() => honey >= honeyDeducted;

    void Awake()
    {
        uiController =GameObject.Find("PlayerUI")
            .GetComponent<PlayerUIController>();
        uiController.UpdateHoney(honey);
    }

    void DoEating()
    {
        timePassed += Time.deltaTime;

        uiController.UpdateEating(timePassed / eatingTime);
        if (timePassed >= eatingTime)
        {
            StopEatingState();
            state = CosumeHoneyState.Cooldown;

            honey -= honeyDeducted;
            uiController.UpdateHoney(honey);
            playerHealth.Heal(healthHealed);
            glupingSource.Play();
        }
    }

    void DoCooldown()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= cooldown)
        {
            timePassed =0f;
            state =CosumeHoneyState.Nothing;
        }
    }

    void StopEatingState()
    {
        uiController.StopEating();
        timePassed =0f;
    }

    public void StartEating()
    {
        if (state !=CosumeHoneyState.Cooldown
            && playerHealth.health !=playerHealth.GetMaxHealth())
        {
            state =CosumeHoneyState.Eating;
            uiController.StartEating();
        }
    }

    public void StopEating()
    {
        if (state == CosumeHoneyState.Eating)
        {
            StopEatingState();
            state =CosumeHoneyState.Nothing;
        }
    }

    void Update()
    {
        if (state ==CosumeHoneyState.Eating)
        {
            DoEating();
        }
        else if (state ==CosumeHoneyState.Cooldown)
        {
            DoCooldown();
        }
    }
}
