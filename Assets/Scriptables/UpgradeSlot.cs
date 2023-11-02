using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeSlot : ScriptableObject
{
    public Sprite sprite;
    public List<int> moneyReq;
    public List<string> description;
    public string Name;
}
