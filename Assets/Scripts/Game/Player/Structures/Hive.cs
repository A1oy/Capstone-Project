using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public enum HiveState
    {
        Cooldown,
        Inactive,
        Generating,
        Generated,
    }

    [SerializeField]
    int honeyToGenerate;

    [SerializeField]
    float cooldown;

    [SerializeField]
    HiveState state =HiveState.Inactive;

    float timeGenerating;

    public void StartHive()
    {
        if (state == HiveState.Inactive)
        {
            timeGenerating =0f;
            state =HiveState.Generating;
        }
    }
    
    public int GetHoney()
    {
        if (state == HiveState.Generated)
        {
            state =HiveState.Inactive;
            return honeyToGenerate;
        }
        return 0;
    }

    public bool HasHoney()
    {
        return state ==HiveState.Generated;
    }

    public bool IsInactive()
    {
        return state ==HiveState.Inactive;
    }

    void FixedUpdate()
    {
        if (state ==HiveState.Generating)
        {
            timeGenerating += Time.deltaTime;
            if (timeGenerating >= cooldown)
            {
                state =HiveState.Generated;
                timeGenerating =0f;
            }
        }
    }
}
