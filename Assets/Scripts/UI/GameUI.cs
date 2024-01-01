using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;

[Serializable]
public class GameEvent : UnityEvent<bool> { }

public class GameUI : MonoBehaviour
{
    float alpha=1f;
    
    [SerializeField]
    float time=0.0f;

    bool isDaylightChanging=false;

    bool isDaytime=true;
    
    [SerializeField]
    int day=1;

    [SerializeField]
    Light2D globalLight;

    [SerializeField]
    float daylightInSeconds;
    
    [SerializeField]
    float nightInSeconds;


    [SerializeField]
    float daylightDecrease;

    [SerializeField]
    float nighttimeIncrease;

    [SerializeField]
    int nWavesEachIncrease;

    [SerializeField]
    float daylightSmoothingInSeconds;

    [SerializeField]
    PlayerUIController uiController;

    [SerializeField]
    PlayerFlashlight flashlight;

    [SerializeField]
    GameWinning winning;

    public GameEvent gameEvent;

    void Awake()
    {
        gameEvent =new GameEvent();
        daylightSmoothingInSeconds = 1.0f/daylightSmoothingInSeconds;
        uiController.UpdateDay(GetDayString());
        uiController.UpdateTime(GetTimeString());
    }

    public void AddDayChangeListener(UnityAction<bool> cb)
    {
        gameEvent.AddListener(cb);
    }

    void DoDaylightChange()
    {
        if (isDaylightChanging)
        {
            if (!isDaytime)
            {
                alpha -= Time.deltaTime * daylightSmoothingInSeconds;
                if (alpha <=0.0f)
                {
                    alpha =0.0f;
                    isDaylightChanging =false;
                }
            }
            else
            {
                alpha += Time.deltaTime *daylightSmoothingInSeconds;
                if (alpha >=1.0f)
                {
                    alpha =1.0f;
                    isDaylightChanging =false;
                }
            }
            globalLight.color = new Color(alpha, alpha, alpha, 1f);
        }
    }

    void HandleDaylightUI()
    {
        time -=Time.deltaTime;
        if (time <0.0f)
        {
            if (isDaytime)
            {
                time =nightInSeconds;
            }
            else
            {
                day++;
                uiController.UpdateDay(GetDayString());
                if (day!=20 && day%nWavesEachIncrease ==0)
                {
                    daylightInSeconds -= daylightDecrease;
                    nightInSeconds += nighttimeIncrease;
                }
                time =daylightInSeconds;
            }
            isDaytime =!isDaytime;
            gameEvent.Invoke(isDaytime);
            
            flashlight.SwitchSpotLight();
            isDaylightChanging =true;
        }
        uiController.UpdateTime(GetTimeString());
        DoDaylightChange();
    }

    void FixedUpdate()
    {
        HandleDaylightUI();
    }

    public int GetDay()
    {
       return day; 
    }

    public bool IsDayTime()
    {
        return isDaytime;
    }

    string GetTimeString()
    {
        int iTime =(int)time;
        int mins =iTime /60;
        int secs = iTime - (mins *60);
        string pad =secs<10? "0":"";
        return  $"{mins}:{pad}{secs}";
    }

    string GetDayString()
    {
        return $"Day {day}";
    }

#if UNITY_EDITOR
    public void DebugFastForwardTime()
    {
        time=0.1f;
    }
#endif
}