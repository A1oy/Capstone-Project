using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invunerability : MonoBehaviour
{
    [SerializeField]
    float seconds;

    float cooldown;

    bool isActive =false;

    public void TriggerInvun()
    {
        isActive =true;
    }

    public bool CanAttack()
    {
        return !isActive;
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= seconds)
            {
                isActive =false;
                cooldown =0f;
            } 
        }
    }
}
