using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    GameObject m_gameRoot;
    float m_sfxVol =0.1f;
    float m_musicVol =0.1f;

    public static AudioManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void SetRoot(GameObject gameObjRoot)
    {
        m_gameRoot =gameObjRoot;
        BroadcastChange();
    }

    public void ClearRoot()
    {
        m_gameRoot =null;
    }

    void BroadcastChange()
    {
        if (m_gameRoot)
        {
            AudioController[] controllers =GameObject.FindObjectsOfType<AudioController>();
            foreach (AudioController audioControl in controllers)
            {
                audioControl.ChangeVolumes(m_sfxVol, m_musicVol);
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        m_musicVol =volume;
        BroadcastChange();
    }

    public void SetSfxVolume(float volume)
    {
        Debug.Log(volume);
        m_sfxVol =volume;
        BroadcastChange();
    }

    public float GetMusicVolume()
    {
        return m_musicVol;
    }

    public float GetSfxVolume()
    {
        return m_sfxVol;
    }
}
