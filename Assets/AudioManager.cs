using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource sfxSource;

    [SerializeField]
    AudioSource musicSource;
    
    public static AudioManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetSfxVolume()
    {
        return sfxSource.volume;
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, 1f);
    }
}
