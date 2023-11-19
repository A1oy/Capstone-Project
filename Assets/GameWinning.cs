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

    void FixedUpdate()
    {
        if (m_gameUI.day==m_winningDays
            && m_globalLight.color.r ==1f)
        {
            SceneManager.LoadScene("Game Win");
        }
    }
}
