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
        NetworkManager0.GetLocalPlayer().GetComponent<PlayerStatus>().SetAimCursor();
    }
}
