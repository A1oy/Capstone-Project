using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DebugCamera : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera perfectCamera;

    [SerializeField]
    CinemachineVirtualCamera debugVmCam;

    [SerializeField]
    Transform playerFollow;    

    [SerializeField]
    GameUI gameManager;

    bool lookAway =false;
#endif

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Period))
        {
            lookAway =!lookAway;
            if (lookAway)
            {
                debugVmCam.Follow =null;
                perfectCamera.assetsPPU =8;
            }
            else
            {
                debugVmCam.Follow =playerFollow;
                perfectCamera.assetsPPU =28;
            }
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            gameManager.DebugFastForwardTime();
        }
#endif
    }
}
