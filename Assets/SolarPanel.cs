using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    [Serializable]
    public struct Slot
    {
        public enum SlotState
        {
            Nothing =0,
            Empty,
            Filled
        };

        [SerializeField]
        public float timeFilled;
        
        [SerializeField]
        public SlotState state;
    }

    [SerializeField]
    float timeToFill;

    [SerializeField]
    Slot[] slots = new Slot[3];

    public bool GetBattery()
    {
        bool hasFilledBattery =false;
        for (int i=0; i<3; i++)
        {
            if (slots[i].state == Slot.SlotState.Filled)
            {
                slots[i].state =Slot.SlotState.Nothing;
                hasFilledBattery =true;
                break; 
            }
        }
        return hasFilledBattery;
    }

    public bool AddBattery()
    {
        bool hasSpace =false;
        for (int i=0; i<3; i++)
        {
            if (slots[i].state == Slot.SlotState.Nothing)
            {
                slots[i].state =Slot.SlotState.Empty;
                hasSpace =true;
                break;
            }
        }
        return hasSpace;
    }

    void FixedUpdate()
    {
        for (int i=0; i<3; i++)
        {
            if (slots[i].state ==Slot.SlotState.Empty)
            {
                slots[i].timeFilled += Time.deltaTime;
                if (slots[i].timeFilled >= timeToFill)
                {
                    slots[i].timeFilled =0f;
                    slots[i].state =Slot.SlotState.Filled;
                }
            }
        }
    }
}
