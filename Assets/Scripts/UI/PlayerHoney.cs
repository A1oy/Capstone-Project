using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem;

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

    [SerializeField]
    PlayerData playerdata;

    [SerializeField]
    int honey;

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

    [SerializeField]
    float timeToCollect;

    [SerializeField]
    float hiveRadius;

    float timeCollecting =0f;

    bool canHiveInteract =false;

    const int hiveLayer =1<<14;

    void OnEnable()
    {
        InputManager.input.Player.ActivateHive.performed += OnActivateHive; 
    }
    
    void OnDisable()
    {
        InputManager.input.Player.ActivateHive.performed -= OnActivateHive;
    }

    void OnActivateHive(InputAction.CallbackContext cc)
    {
        Collider2D collider =Physics2D.OverlapCircle(transform.position,
                hiveRadius,
                hiveLayer);
        if (collider && collider.GetComponent<Hive>().IsInactive())
        {
            collider.gameObject.GetComponent<Hive>().StartHive();
            canHiveInteract =false;
            uiController.DisableHiveActivate();
        }
    }

    void Awake()
    {
        uiController =GameObject.Find("PlayerUI")
            .GetComponent<PlayerUIController>();
        uiController.UpdateHoney();
    }

    public void RefreshHoney()
    {
        uiController.UpdateHoney();
    }

    public int GetHoney()
    {
        return honey;
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
            playerdata.AddHoneyCosumed(honeyDeducted);

            uiController.UpdateHoney();
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

    void AddHoney(int honey)
    {
        if (this.honey <= 200)
        {
            this.honey +=honey;
            playerdata.AddHoneyCollected(honey);
        }
    }
    
    public bool Purchase(UpgradeData data)
    {
        if (this.honey >=data.honeyNeeded)
        {
            honey -= data.honeyNeeded;
            return true;
        }
        return false;
    }

    void FixedUpdate()
    {
        if (!canHiveInteract)
        {
            Collider2D collider =Physics2D.OverlapCircle(transform.position,
                hiveRadius,
                hiveLayer);
            if (collider)
            {
                canHiveInteract =true;
                if (collider.gameObject.GetComponent<Hive>().HasHoney())
                {
                    uiController.StartHoneyCollecting();
                }
                else if (collider.gameObject.GetComponent<Hive>().IsInactive())
                {
                    uiController.EnableHiveActivate();
                }
            }
        }
        else if (canHiveInteract)
        {
            Collider2D collider =Physics2D.OverlapCircle(transform.position,
                hiveRadius,
                hiveLayer);
            if (!collider)
            {
                
                canHiveInteract =false;
                Debug.Log(uiController.IsHiveActivateEnabled());

                if (uiController.IsCollecting())
                {
                    uiController.StopHoneyCollecting();
                }
                else if (uiController.IsHiveActivateEnabled())
                {
                    uiController.DisableHiveActivate();
                }
                timeCollecting =0f;
            }
            else 
            {
                timeCollecting +=Time.deltaTime;
                if (timeCollecting >= timeToCollect)
                {
                    uiController.StopHoneyCollecting();
                    timeCollecting =0f;
                    canHiveInteract =false;
                    AddHoney(collider.gameObject.GetComponent<Hive>().GetHoney());
                    uiController.UpdateHoney();
                }
                else
                {
                    uiController.UpdateCollecting(timeCollecting/timeToCollect);
                }
            }
        }

        if (state ==CosumeHoneyState.Eating)
        {
            DoEating();
        }
        else if (state ==CosumeHoneyState.Cooldown)
        {
            DoCooldown();
        }
    }

    void OnDrawGizmos()
    {
        Color color =new Color(0f, 0f, 1f, 0.4f);
        Gizmos.color =color;
        Gizmos.DrawSphere(transform.position, hiveRadius);
    }
}
