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

    bool isflOff =true;
    bool isslOff =true;

    void OnEnable()
    {
        InputManager.input.Player.Flashlight.performed += OnFlashlight;
    }

    void OnDisable()
    {
        InputManager.input.Player.Flashlight.performed -= OnFlashlight;
    }

    void OnFlashlight(InputAction.CallbackContext cc)
    {
        isflOff =!isflOff;
        flashLight.intensity =isflOff ? 0f : flIntensity;
    }

    public void SwitchSpotLight()
    {
        isslOff =!isslOff;
        spotLight.intensity = isslOff ? 0f: slIntensity;
    }
}