using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IDamageValue : MonoBehaviour
{
    [SerializeField]
    TextMeshPro damagetxt;

    public string text { set { damagetxt.text = value; }}
}
