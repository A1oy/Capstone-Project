using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


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
    UnityEngine.Rendering.Universal.Light2D globalLight;

    public TMP_Text interactableText;

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

    void Awake()
    {
        time =daylightInSeconds;
        daylightSmoothingInSeconds = 1.0f/daylightSmoothingInSeconds;
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
                if (day!=20 && day%nWavesEachIncrease ==0)
                {
                    daylightInSeconds -= daylightDecrease;
                    nightInSeconds += nighttimeIncrease;
                }
                time =daylightInSeconds;
            }
            isDaytime =!isDaytime;

            gameObject.BroadcastMessage("OnDaylightChange", isDaytime, SendMessageOptions.DontRequireReceiver);
            isDaylightChanging =true;
        }
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

    public string GetTimeString()
    {
        int iTime =(int)time;
        int mins =iTime /60;
        int secs = iTime - (mins *60);
        string pad =secs<10? "0":"";
        return  $"{mins}:{pad}{secs}";
    }
#if UNITY_EDITOR
    public void DebugFastForwardTime()
    {
        time=1f;
    }
#endif
}