using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager0 : MonoBehaviour
{
    static public GameObject GetLocalPlayer()
    {
        return GameObject.FindWithTag("Player");
    }
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
