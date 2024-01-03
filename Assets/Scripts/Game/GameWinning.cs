using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;

public class GameWinning : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;
    
    [SerializeField]
    Light2D globalLight;

    [SerializeField]
    int winningDays;

    bool doDaylightCheck=false;

    UnityAction<bool> daylightChangeAction;

    void Start()
    {
        daylightChangeAction += OnDaylightChange;
        gameUI.AddDaylightChangeListener(daylightChangeAction);
    }

    void FixedUpdate()
    {
        if (doDaylightCheck
            && globalLight.color.r ==1f)
        {
            DontDestroyOnLoad(GameObject.Find("GameplayManager"));
            SceneManager.LoadScene("Game Win");
        }
    }

    void OnDaylightChange(bool isDayTime)
    {
        if (gameUI.GetDay()==winningDays)
        {
            doDaylightCheck =true;
        }
    }
}
