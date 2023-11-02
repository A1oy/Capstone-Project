using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isBuildMode =false;


    void OnDestroy()
    {
        if (gameObject.GetComponent<Health>().isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isBuildMode =!isBuildMode;
            GetComponent<Placement>().placer.SetActive(isBuildMode);
        }
    }
}
