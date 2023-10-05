using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int honey=3;

    void OnDestroy()
    {
        if (gameObject.GetComponent<Health>().isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
