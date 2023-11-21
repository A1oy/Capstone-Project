using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinning : MonoBehaviour
{
    [SerializeField]
    GameUI m_gameUI;
    
    [SerializeField]
    UnityEngine.Rendering.Universal.Light2D m_globalLight;

    [SerializeField]
    int m_winningDays;

    bool doDaylightCheck=false;

    void FixedUpdate()
    {
        if (doDaylightCheck
            && m_globalLight.color.r ==1f)
        {
            GameObject instance =new GameObject();
            instance.tag ="Player";
            PlayerInventory inventory =instance.AddComponent(typeof(PlayerInventory)) as PlayerInventory;
            inventory.AddScore(NetworkManager.GetLocalPlayer().GetComponent<PlayerInventory>().GetScore());
            DontDestroyOnLoad(instance);

            SceneManager.LoadScene("Game Win");
        }
    }

    void OnDaylightChange(bool isDayTime)
    {
        if (m_gameUI.GetDay()==m_winningDays)
        {
            doDaylightCheck =true;
        }
    }
}
