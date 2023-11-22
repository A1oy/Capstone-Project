using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Rendering.Universal.Light2D m_flashlight;

    [SerializeField]
    UnityEngine.Rendering.Universal.Light2D m_spotlight;

    void OnDaylightChange(bool isDayTime)
    {
        m_flashlight.intensity =isDayTime ? 0f:1f;
        m_spotlight.intensity = isDayTime ? 0f:0.5f;
    }

}