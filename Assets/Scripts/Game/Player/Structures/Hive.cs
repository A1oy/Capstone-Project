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

    public int GetHoney()
    {
        Destroy(gameObject);
        return honeyToGenerate;
    }

    public bool HasHoney()
    {
        return true;
    }

    public bool IsInactive()
    {
        return false;
    }
}
