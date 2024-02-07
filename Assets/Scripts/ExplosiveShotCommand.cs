using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveShotCommand : PostShotBehaviourCommand
{
    public ExplosiveShotCommand(PlayerData data){
        
    }
    public override void Apply(GameObject bullet)
    {
        bullet.AddComponent<ExplosiveEffect>();
    }

    public override int GetPrecedence()
    {
        return 1;
    }
}
