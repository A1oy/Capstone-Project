using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeSlot : ScriptableObject
{
    [SerializeField]
    Sprite m_sprite;
    
    [SerializeField]
    List<int> m_moneyReq;
    
    [SerializeField]
    string m_description;
    
    [SerializeField]
    string m_name;

    
    public int GetMoneyReq(int level) { return m_moneyReq[level]; }
    public string Name {get { return m_name; }}
    public string Desc {get {return m_description; }}
    public Sprite Sprite{get {return m_sprite; }}
}
