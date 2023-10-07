using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static List<GameObject> gameInteractables = new List<GameObject>();

    public bool isEnabled =true;

    public float touchRadius =2.0f;
    public string text;

    void Start()
    {
        gameInteractables.Add(gameObject);
    }

    void Destroy()
    {
        gameInteractables.Remove(gameObject);
    }
}
