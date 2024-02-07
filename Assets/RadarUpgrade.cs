using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarUpgrade : MonoBehaviour
{
    [SerializeField]
    PlayerRadar radar;
    public void OnUpgrade()
    {
        radar.UpgradeDelay();
    }
}
