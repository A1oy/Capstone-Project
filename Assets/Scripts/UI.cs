using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    void OnEnable()
    {
        PlayerStatus.ClearCursor();
    }

    void OnDisable()
    {
        GameObject.Find("Player").GetComponent<PlayerStatus>().SetAimCursor();
    }
}
