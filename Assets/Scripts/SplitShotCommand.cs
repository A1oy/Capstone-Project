using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SplitShotCommand : ShotBehaviourCommand
{
    public delegate void OnAnimalKilled(); 

    public override void Execute(List<Bullet> bullets)
    {
        
    }

    public override int GetPrecedence()
    {
        throw new System.NotImplementedException();
    }
}
