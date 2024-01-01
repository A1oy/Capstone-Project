using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingFX : MonoBehaviour
{
    [SerializeField]
    AudioSource walkingFX;

    public void StartWalking()
    {
        walkingFX.Play();
    }

    public void StopWalking()
    {
        walkingFX.Stop();
        walkingFX.time =0f;
    }
}