using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    [SerializeField]
    HoneyProduction m_honeyProduction;
    
    void OnDead()
    {
        Debug.Log("Dead ");
        Destroy(m_honeyProduction);
    }
}
