using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

#nullable enable

public class GameUI : MonoBehaviour
{
    float time=0.0f;
    float alpha=0.0f;

    bool isDaylightChanging=false;

    public static bool isDaytime=true;
    static public int day=1;

    public GameObject player =null!;
    public GameObject blackout =null!;

    public TMP_Text playerHoney =null!;
    public TMP_Text playerGrenade =null!;
    public TMP_Text playerMoney =null!;

    public TMP_Text dayText =null!;
    public TMP_Text timeText =null!;
    public TMP_Text interactableText =null!;

    public float daylightInSeconds;
    public float nightInSeconds;
    public float daylightSmoothingInSeconds;

    // Update is called once per frame

    void Start()
    {
        time =daylightInSeconds;
        dayText.text ="Day 1";
        daylightSmoothingInSeconds = 1.0f/daylightSmoothingInSeconds;
    }

    void DoDaylightChange()
    {
        if (isDaylightChanging)
        {
            if (isDaytime)
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
            SpriteRenderer sr =blackout!.GetComponent<SpriteRenderer>();
            sr.color = new Color(0.0f, 0.0f, 0.0f, alpha);
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
                time =daylightInSeconds;
                day++;
                dayText.text = $"Day {day}";
            }
            isDaytime =!isDaytime;
            isDaylightChanging =true;
        }
        int iTime =(int)time;
        int mins =iTime /60;
        int secs = iTime - (mins *60);
        string pad =secs<10? "0":"";
        timeText.text = $"{mins}:{pad}{secs}";
        DoDaylightChange();
    }

    void Update()
    {
        HandleDaylightUI();

        playerHoney.text = Convert.ToString(player!.GetComponent<Player>().honey);
        playerGrenade.text =Convert.ToString(player!.GetComponent<Player>().grenades);
        playerMoney.text = $"{player!.GetComponent<Player>().money}";
    }
}