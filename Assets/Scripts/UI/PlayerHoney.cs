using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem;

public class PlayerHoney : MonoBehaviour
{
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

    float timePassed = 0f;

    bool EnoughHoney() => honey >= honeyDeducted;

    [SerializeField]
    float timeToCollect;

    [SerializeField]
    float hiveRadius;

    float timeCollecting =0f;

    bool canHiveInteract =false;

    const int hiveLayer =1<<14;

    void OnActivateHive(InputAction.CallbackContext cc)
    {
        Collider2D collider =Physics2D.OverlapCircle(transform.position,
                hiveRadius,
                hiveLayer);
        if (collider)
        {
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

    public void DoEating()
    {
        if (EnoughHoney())
        {
            honey-=honeyDeducted;
            playerHealth.Heal(healthHealed);
            uiController.UpdateHealth(GetComponent<Health>());
            uiController.UpdateHoney();

            glupingSource.Play();
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
    
    public bool Purchase(int amt)
    {
        if (this.honey >=amt)
        {
            honey -= amt;
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
                
                if (collider.gameObject.GetComponent<Hive>().HasHoney())
                {
                    canHiveInteract =true;
                    uiController.StartHoneyCollecting();
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
    }

    void OnDrawGizmos()
    {
        Color color =new Color(0f, 0f, 1f, 0.4f);
        Gizmos.color =color;
        Gizmos.DrawSphere(transform.position, hiveRadius);
    }
}
