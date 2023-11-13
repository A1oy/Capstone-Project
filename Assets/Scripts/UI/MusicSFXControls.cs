using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class MusicSFXControls : MonoBehaviour
{
    [SerializeField]
    Slider musicVolumeSlider;

    [SerializeField]
    Slider sfxVolumeSlider; 

    [SerializeField]
    TMP_Text musicVolumeMagnitude;

    [SerializeField]
    TMP_Text sfxVolumeMagnitude;

    void Awake()
    {
        AudioListener.volume = musicVolumeSlider.value / 100f;
        musicVolumeMagnitude.text = Convert.ToString(musicVolumeSlider.value);
        sfxVolumeMagnitude.text = Convert.ToString(sfxVolumeSlider.value);
    }

    public void OnMusicVolumeChange()
    {
        musicVolumeMagnitude.text = Convert.ToString(musicVolumeSlider.value);
        AudioListener.volume = musicVolumeSlider.value / 100f; 
    }

    public void OnSFXVolumeChange()
    {
        sfxVolumeMagnitude.text = Convert.ToString(sfxVolumeSlider.value); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
