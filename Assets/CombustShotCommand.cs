using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustShotCommand : PostShotBehaviourCommand
{
    PlayerData player;
    GameObject explosionPrefab;

    public CombustShotCommand()
    {
        player =GameObject.FindWithTag("Player")
            .GetComponent<PlayerShooting>()
            .player;
        explosionPrefab =Resources.Load<GameObject>("BombExplodefx");
    }
    
     public override void Apply(GameObject bullet)
     {
        CombustEffect comEff =bullet.AddComponent<CombustEffect>();
        comEff.player =player;
        comEff.explosionPrefab =explosionPrefab;
     }

     public override int GetPrecedence()
     {
        return 1;
     }
}
