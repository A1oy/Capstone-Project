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

    bool lookAway =false;
#endif

    [SerializeField]
    GameUI gameManager;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            gameManager.DebugFastForwardTime();
        }
    }
}
