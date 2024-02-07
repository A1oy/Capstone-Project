using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveShotCommand : PostShotBehaviourCommand
{
    PlayerData player;
    GameObject explosionPrefab;

    int count=0;

    public ExplosiveShotCommand()
    {
        player =GameObject.FindWithTag("Player")
            .GetComponent<PlayerShooting>()
            .player;
        explosionPrefab =Resources.Load<GameObject>("BombExplodefx");
    }
    public override void Apply(GameObject bullet)
    {
        if (count>3)
        {
            count=0;
            ExplosiveEffect expe =bullet.AddComponent<ExplosiveEffect>();
            expe.player = player;
            expe.explosionPrefab =explosionPrefab;
        }
        else
        {
            count++;
        }
    }

    public override int GetPrecedence()
    {
        return 1;
    }
}
