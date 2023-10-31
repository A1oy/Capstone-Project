using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlaceableObject : ScriptableObject
{
    public Sprite sprite;
    public GameObject objectPrefab;
    public int cost;
}
