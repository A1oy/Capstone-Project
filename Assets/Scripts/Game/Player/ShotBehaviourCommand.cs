using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ShotBehaviourCommand : IComparable<ShotBehaviourCommand>
{
    public abstract void Execute(Transform fp, GameObject prefab, List<GameObject> bullets);

    public abstract int GetPrecedence();

    public int CompareTo(ShotBehaviourCommand otherCommand)
    {
        return GetPrecedence().CompareTo(otherCommand.GetPrecedence());
    }
}