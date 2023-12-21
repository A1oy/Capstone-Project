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
        NetworkManager.GetLocalPlayer().GetComponent<PlayerStatus>().SetAimCursor();
    }
}
