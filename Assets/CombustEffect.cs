using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustEffect : MonoBehaviour
{
    public PlayerData player;
    public GameObject explosionPrefab;

    public void OnBulletHit(GameObject go)
    {
        Combust cmb=go.AddComponent<Combust>();
        cmb.player =player;
        cmb.explosionPrefab =explosionPrefab;
    }
}
