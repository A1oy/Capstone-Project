using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitIIShotCommand : ShotBehaviourCommand
{
    SplitShotCommand cmd;
    PlayerData player;

    public SplitIIShotCommand(SplitShotCommand cmd)
    {
        this.cmd =cmd;
    }

    public override void Execute(Transform fp, GameObject prefab, List<GameObject> bullets)
    {
        if (cmd.HasReachedAmount())
        {
            Quaternion quat =fp.rotation;
            quat.eulerAngles += new Vector3(0f, 0f, 50f);
            bullets.Add(Object.Instantiate(prefab, fp.position, quat));
            quat.eulerAngles -= new Vector3(0f, 0f, 100f);
            bullets.Add(Object.Instantiate(prefab, fp.position, quat));
        }
    }

    public override int GetPrecedence()
    {
        return 1;
    }
}
