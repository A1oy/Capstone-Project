using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalEffect2 : MonoBehaviour
{
    [SerializeField]
    float effectsInSeconds;

    float cooldown;

    void FixedUpdate()
    {
        cooldown +=Time.deltaTime;
        if (cooldown>effectsInSeconds)
        {
            Destroy(this);
        }
    }
}
