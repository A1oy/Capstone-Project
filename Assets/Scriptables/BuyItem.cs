using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BuyItem : ScriptableObject
{
    [SerializeField]
    Sprite sprite;

    [SerializeField]
    string description;
    
    [SerializeField]
    int amt;    
}