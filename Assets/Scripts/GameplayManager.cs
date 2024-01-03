using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public PlayerData players;

    public int GetScore()
    {
        return players.honeyCollected  * 50 +
            players.animalsKilled * 100 +
            players.honeyCosumed *5;
    }
}
