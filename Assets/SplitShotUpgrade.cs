using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitShotUpgrade : MonoBehaviour
{
    public void OnUpgrade()
    {
        PlayerShooting ps =  GameObject.Find("Player").GetComponent<PlayerShooting>();
        ps.AddShotBehaviourCommand(new SplitShotCommand(
            ps.player
            ));
    }
}
