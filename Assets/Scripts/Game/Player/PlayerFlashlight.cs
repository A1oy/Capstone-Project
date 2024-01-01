using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

[Serializable]
public class Flashlight
{
    
    [Serializable]
    public struct Battery
    {
        public enum BatteryState
        {
            NotEmpty =0,
            Empty,
            TakenOut,
        };

        [SerializeField]
        public float timeUsed;
        public BatteryState state;
    };

    [SerializeField]
    float timeToDrain;

    [SerializeField]
    Battery[] batteries;

    int indexToDrain;

    public bool IsNotEmpty()
    {
        return indexToDrain !=-1;
    }

    public Flashlight()
    {
        batteries = new Battery[3];
        indexToDrain =0;
    }

    public void Update(float deltaTime, PlayerUIController uiController)
    {
        if (indexToDrain!=-1)
        {
            batteries[indexToDrain].timeUsed += deltaTime;
            if (batteries[indexToDrain].timeUsed >= timeToDrain)
            {
                batteries[indexToDrain].timeUsed =0f;
                batteries[indexToDrain].state = Battery.BatteryState.Empty;
                uiController.UpdateActiveBattery(0f);

                indexToDrain =-1;
                for (int i=0; i<3; i++)
                {
                    if (i!=indexToDrain)
                    {
                        if (batteries[i].state == Battery.BatteryState.NotEmpty)
                        {
                            indexToDrain =i;
                            break;
                        }
                    }
                }
            }
            uiController.UpdateActiveBattery(GetActiveUsed());
        }
    }

    public bool HasEmptyBattery()
    {
        bool hasEmpty =false;
        for (int i=0; i<3; i++)
        {
            if (batteries[i].state == Battery.BatteryState.Empty)
            {
                hasEmpty =true;
            }
        }
        return hasEmpty;
    }

    public bool HasSpace()
    {
        bool hasSpace =false;
        for (int i=0; i<3; i++)
        {
            if (batteries[i].state == Battery.BatteryState.TakenOut)
            {
                hasSpace =true;
            }
        }
        return hasSpace;
    }

    public void RemoveBattery()
    {
        for (int i=0; i<3; i++)
        {
            if (batteries[i].state == Battery.BatteryState.Empty)
            {
                batteries[i].state =Battery.BatteryState.TakenOut;
            }
        }
    }

    public void AddBattery()
    {
        for (int i=0; i<3; i++)
        {
            if (batteries[i].state == Battery.BatteryState.TakenOut)
            {
                batteries[i].state =Battery.BatteryState.NotEmpty;
            }
        }
    }

    public float GetActiveUsed()
    {
        return 1f -(batteries[indexToDrain].timeUsed /timeToDrain);
    }
}

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

    [SerializeField]
    Flashlight fl;

    [SerializeField]
    PlayerUIController uiController;

    [SerializeField]
    float radiusInteract;

    void OnEnable()
    {
        InputManager.input.Player.Flashlight.performed += OnFlashlight;
        InputManager.input.Player.AddBattery.performed += OnAddBattery;
        InputManager.input.Player.RemoveBattery.performed += OnRemoveBattery;
    }

    void OnDisable()
    {
        InputManager.input.Player.Flashlight.performed -= OnFlashlight;
    }

    void OnFlashlight(InputAction.CallbackContext cc)
    {
        if (fl.IsNotEmpty())
        {
            SwitchFlashLight();
        }
    }

    Collider2D SolarPanelNearby()
    {
        const int layer =1<<13;
        Collider2D solarPanel =Physics2D.OverlapCircle(transform.position, radiusInteract, layer);

        return solarPanel;
    }

    void OnAddBattery(InputAction.CallbackContext cc)
    {
        if (fl.HasEmptyBattery())
        {
            Collider2D solarPanel =SolarPanelNearby();
            if (solarPanel)
            {
                if (solarPanel.GetComponent<SolarPanel>().AddBattery())
                {
                    fl.RemoveBattery();
                    uiController.RemoveEmptyBattery();
                    if (!solarPanel.GetComponent<SolarPanel>().HasSpace()
                        || !fl.HasEmptyBattery())
                    {
                        uiController.DisableInsertBattery();
                    }
                }
            }
        }
    }

    void OnRemoveBattery(InputAction.CallbackContext cc)
    {
        if (fl.HasSpace())
        {
            Collider2D solarPanel =SolarPanelNearby();
            if (solarPanel)
            {
                if (solarPanel.GetComponent<SolarPanel>().GetBattery())
                {
                    fl.AddBattery();
                    uiController.AddFilledBattery();
                    if (!solarPanel.GetComponent<SolarPanel>().HasFilledBattery()
                        || !fl.HasSpace())
                    {
                        uiController.DisableGetBattery();
                    }
                }
            }
        }
    }

    public void SwitchFlashLight()
    {
        isflOff =!isflOff;
        flashLight.intensity =isflOff ? 0f : flIntensity;
    }

    public void SwitchSpotLight()
    {
        isslOff =!isslOff;
        spotLight.intensity = isslOff ? 0f: slIntensity;
    }

    void FixedUpdate()
    {
        if (!isflOff)
        {
            fl.Update(Time.deltaTime, uiController);
            if (!fl.IsNotEmpty())
            {
                SwitchFlashLight();
            }
        }
        Collider2D solarPanel =SolarPanelNearby();
        if (solarPanel)
        {
            if (!uiController.InsertBatteryEnabled()
                && solarPanel.GetComponent<SolarPanel>().HasSpace() && fl.HasEmptyBattery())
            {
                uiController.EnableInsertBattery();
            }
            if (!uiController.GetBatteryEnabled()
                && solarPanel.GetComponent<SolarPanel>().HasFilledBattery() && fl.HasSpace())
            {
                uiController.EnableGetBattery();
            }
        }
        else
        {
            if (uiController.InsertBatteryEnabled())
            {
                uiController.DisableInsertBattery();
            }
            if (uiController.GetBatteryEnabled())
            {
                uiController.DisableGetBattery();
            }
        }
    }

    void OnDrawGizmos()
    {
        Color color= Color.yellow;
        color.a =0.4f;
        Gizmos.color =color;
        Gizmos.DrawSphere(transform.position, radiusInteract);
    }
}