using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    List<AudioSource> m_sfxSources;

    [SerializeField]
    List<AudioSource> m_musicSources;

    void Awake()
    {
        ChangeVolumes(AudioManager.instance.GetSfxVolume(), AudioManager.instance.GetMusicVolume());
    }

    public void ChangeVolumes(float sfxVol, float musicVol)
    {
        foreach (AudioSource src in m_sfxSources)
        {
            src.volume =sfxVol;
        }
        foreach (AudioSource src in m_musicSources)
        {
            src.volume =musicVol;
        }
    }
}
