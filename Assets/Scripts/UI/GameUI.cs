using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    float alpha=1f;
    public float time=0.0f;

    bool isDaylightChanging=false;

    public bool isDaytime=true;
    public int day=1;

    [SerializeField]
    UnityEngine.Rendering.Universal.Light2D globalLight;

    public TMP_Text dayText =null!;
    public TMP_Text timeText =null!;
    public TMP_Text interactableText =null!;

    public float daylightInSeconds;
    public float nightInSeconds;
    public float daylightSmoothingInSeconds;

    [SerializeField]
    PlayerInventory m_inventory;

    [SerializeField]
    TMP_Text moneyAmount;

    [SerializeField]
    Slider honeySlider;

    [SerializeField]
    TMP_Text honeyAmount;

    [SerializeField]
    AudioSource musicSource;

    void Awake()
    {
        time =daylightInSeconds;
        dayText.text ="Day 1";
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
                time =daylightInSeconds;
                day++;
                dayText.text = $"Day {day}";
            }
            isDaytime =!isDaytime;
            gameObject.BroadcastMessage("OnDaylightChange", isDaytime, SendMessageOptions.DontRequireReceiver);
            isDaylightChanging =true;
        }
        int iTime =(int)time;
        int mins =iTime /60;
        int secs = iTime - (mins *60);
        string pad =secs<10? "0":"";
        timeText.text = $"{mins}:{pad}{secs}";
        DoDaylightChange();
    }

    void HandlePlayerInventoryUI()
    {
        honeySlider.value =m_inventory.honey;
        honeyAmount.text =$"{m_inventory.honey}%";
        moneyAmount.text =Convert.ToString(m_inventory.money);
    }

    void FixedUpdate()
    {
        musicSource.volume = AudioManager.instance.GetMusicVolume();
    }

    void Update()
    {
        HandleDaylightUI();
        HandlePlayerInventoryUI();
    }
}