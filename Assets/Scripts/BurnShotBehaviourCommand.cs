using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnShotBehaviourCommand : PostShotBehaviourCommand
{
    PlayerData player;
    GameObject burnfx;

    public BurnShotBehaviourCommand()
    {
        player =GameObject.FindWithTag("Player").
            GetComponent<PlayerShooting>()
            .player;
        burnfx =Resources.Load<GameObject>("Burnfx");
    }

    public override void Apply(GameObject bullet)
    {
        if (UnityEngine.Random.value<=0.15f)
        {
            BurnEffect be =bullet.AddComponent<BurnEffect>();
            be.player =player;
            be.burnfx =burnfx;
        }
    }

    public override int GetPrecedence()
    {
        return 1;
    }

}
