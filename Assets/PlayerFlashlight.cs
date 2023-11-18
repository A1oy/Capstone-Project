using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Rendering.Universal.Light2D flashlight;

    void OnDaylightChange(bool isDayTime)
    {
        flashlight.intensity = isDayTime ? 0:1;    
    }
}
