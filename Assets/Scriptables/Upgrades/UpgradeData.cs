using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="UpgradeData")]
public class UpgradeData: ScriptableObject
{
    [SerializeField]
    public int honeyNeeded;
}