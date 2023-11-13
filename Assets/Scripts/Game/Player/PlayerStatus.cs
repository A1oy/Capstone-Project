using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerStatus : MonoBehaviour
{
    [System.NonSerialized]
    public bool isBuildMode =false;

    [SerializeField]
    Health health;

    [SerializeField]
    Placement placement;

#if UNITY_EDITOR
    [SerializeField]
    GameObject debugVmCamObj;

    [SerializeField]
    CinemachineVirtualCamera debugVmCam;
    bool lookAway =false;

    [SerializeField]
    GameUI gameManager;
#endif


    void OnDestroy()
    {
        if (health.isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isBuildMode =!isBuildMode;
            placement.placer.SetActive(isBuildMode);
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Period))
        {
            lookAway =!lookAway;
            if (lookAway)
            {
                debugVmCam.m_Lens.OrthographicSize =14f;
                debugVmCam.Follow =null;
                debugVmCamObj.transform.position = new Vector3(0f, 0f, -10f);
            }
            else
            {
                debugVmCam.m_Lens.OrthographicSize =5f;
                debugVmCam.Follow =transform;
            }
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            gameManager.time =1f;
        }
#endif
    }
}