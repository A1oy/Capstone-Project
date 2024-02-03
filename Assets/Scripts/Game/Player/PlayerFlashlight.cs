using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;


public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField]
    Light2D flashLight;

    [SerializeField]
    Light2D spotLight;

    [SerializeField]
    float flIntensity;

    [SerializeField]
    float slIntensity;

    public void SwitchFlashLight()
    {
        flashLight.intensity =(flashLight.intensity!=0f) ? 0f : flIntensity;
    }

    public void SwitchSpotLight()
    {
        spotLight.intensity = (spotLight.intensity!=0f) ? 0f: slIntensity;
    }
}
