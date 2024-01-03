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
    SpriteRenderer sr;

    [SerializeField]
    int honeyToGenerate;

    [SerializeField]
    float cooldown;

    [SerializeField]
    float timeToGenerate;

    [SerializeField]
    Sprite emptyHive;

    [SerializeField]
    Sprite halfFullHive;

    [SerializeField]
    Sprite fullHive;

    [SerializeField]
    HiveState state =HiveState.Inactive;

    float timeDone;

    [SerializeField]
    [Range(0, 1)]
    float spriteChangeThreshold;

    Color inactiveColor =new Color(0.6f, 0.6f, 0.6f, 1f);

    public void StartHive()
    {
        if (state == HiveState.Inactive)
        {
            timeDone =0f;
            state =HiveState.Generating;
            sr.color =Color.white;
        }
    }
    
    public int GetHoney()
    {
        if (state == HiveState.Generated)
        {
            state =HiveState.Cooldown;
            sr.color =inactiveColor;
            sr.sprite = emptyHive;
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
            timeDone += Time.deltaTime;
            if (timeDone >= timeToGenerate)
            {
                state =HiveState.Generated;
                sr.sprite = fullHive;
                timeDone =0f;
            }
            else if ((timeDone/timeToGenerate) >=spriteChangeThreshold)
            {
                sr.sprite =halfFullHive;
            }
        }
        else if (state == HiveState.Cooldown)
        {
            timeDone += Time.deltaTime;
            if (timeDone >= cooldown)
            {
                state =HiveState.Inactive;
                timeDone =0f;
            }
        }
    }
}
