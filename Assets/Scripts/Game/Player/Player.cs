using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int honey=3;
    public int grenades =2;
    public int money=0;

    void OnDestroy()
    {
        if (gameObject.GetComponent<Health>().isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
