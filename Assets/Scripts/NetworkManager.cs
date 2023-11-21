using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
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
