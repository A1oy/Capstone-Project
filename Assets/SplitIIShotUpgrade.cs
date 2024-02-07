using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitIIShotUpgrade : MonoBehaviour
{
    public void OnUpgrade()
    {
        PlayerShooting ps =  GameObject.Find("Player").GetComponent<PlayerShooting>();
        ps.AddShotBehaviourCommand(new SplitIIShotCommand(ps.
            GetShotBehaviourCommand<SplitShotCommand>()));
    }
}
