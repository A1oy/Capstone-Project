using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SplitShotCommand : ShotBehaviourCommand
{
    int animalsKilled =0;

    public SplitShotCommand(PlayerData player)
    {
        player.AddAnimalsKilledListener(OnAnimalKilled);
    }

    public void OnAnimalKilled()
    {
        animalsKilled ++;
    }

    public bool HasReachedAmount()
    {
        return animalsKilled>=5;
    }

    public override void Execute(Transform fp, GameObject prefab, List<GameObject> bullets)
    {
        if (HasReachedAmount())
        {
            animalsKilled-=5;
            Quaternion quat =fp.rotation;
            quat.eulerAngles += new Vector3(0f, 0f, 30f);
            bullets.Add(Object.Instantiate(prefab, fp.position, quat));
            quat.eulerAngles -= new Vector3(0f, 0f, 60f);
            bullets.Add(Object.Instantiate(prefab, fp.position, quat));
            quat.eulerAngles += new Vector3(0f, 0f, 30f);
            bullets.Add(Object.Instantiate(prefab, fp.position, quat));
        }
    }

    public override int GetPrecedence()
    {
        return 2;
    }
}
