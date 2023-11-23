using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBait : MonoBehaviour
{
    void OnDead()
    {
        Destroy(gameObject);
    }
}
