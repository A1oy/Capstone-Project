using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public abstract class PostShotBehaviourCommand : IComparable<PostShotBehaviourCommand>
{
    public abstract void Apply(Bullet bullet); 

    public abstract int GetPrecedence();

    public int CompareTo(PostShotBehaviourCommand otherCommand)
    {
        return GetPrecedence().CompareTo(otherCommand.GetPrecedence()); 
    }
}