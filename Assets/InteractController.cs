using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractController : MonoBehaviour
{
    public static InteractController singleton =null!;
    [SerializeField]
    private TMP_Text interactableText =null!;

    public string text { set { interactableText.text = value==null? "":value; }}

    void Awake()
    {
        singleton =this;
    }
}