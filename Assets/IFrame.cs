using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrame : MonoBehaviour
{
    [SerializeField]
    float iFramesInSeconds;

    float cooldown;

    bool isActive =false;

    public void TriggerFrames()
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
            if (cooldown >= iFramesInSeconds)
            {
                isActive =false;
                cooldown =0f;
            } 
        }
    }
}
