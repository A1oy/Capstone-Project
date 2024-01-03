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
    Sprite emptyHive;

    [SerializeField]
    Sprite halfFullHive;

    [SerializeField]
    Sprite fullHive;

    [SerializeField]
    HiveState state =HiveState.Inactive;

    float timeGenerating;

    [SerializeField]
    [Range(0, 1)]
    float spriteChangeThreshold;

    Color inactiveColor =new Color(0.6f, 0.6f, 0.6f, 1f);

    public void StartHive()
    {
        if (state == HiveState.Inactive)
        {
            timeGenerating =0f;
            state =HiveState.Generating;
            sr.color =Color.white;
        }
    }
    
    public int GetHoney()
    {
        if (state == HiveState.Generated)
        {
            state =HiveState.Inactive;
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
            timeGenerating += Time.deltaTime;
            if (timeGenerating >= cooldown)
            {
                state =HiveState.Generated;
                sr.sprite = fullHive;
                timeGenerating =0f;
            }
            else if ((timeGenerating/cooldown) >=0.6f)
            {
                sr.sprite =halfFullHive;
            }
        }
    }
}
