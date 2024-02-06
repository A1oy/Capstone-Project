using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnShotBehaviourCommand : PostShotBehaviourCommand
{
    public BurnShotBehaviourCommand(PlayerData data){
        
    }
    public override void Apply(GameObject bullet)
    {
        bullet.AddComponent<BurnEffect>();
    }

    public override int GetPrecedence()
    {
        return 1;
    }

}
