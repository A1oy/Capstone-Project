using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    List<PlayerData> players;

    [SerializeField]
    PlayerUI playerUI;

    void Awake()
    {
        NetworkManager.GetLocalPlayer()
            .GetComponent<PlayerStatus>()
            .SetUI(playerUI);
    }
}
