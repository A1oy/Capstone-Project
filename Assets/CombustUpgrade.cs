using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustUpgrade : MonoBehaviour
{
    public void OnUpgrade()
    {
        PlayerShooting ps =  GameObject.Find("Player").GetComponent<PlayerShooting>();
        ps.AddPostShotBehaviourCommand(new CombustShotCommand());
    }
}
