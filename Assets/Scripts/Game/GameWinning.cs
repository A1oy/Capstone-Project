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
            DontDestroyOnLoad(GameObject.Find("GameplayManager"));
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
