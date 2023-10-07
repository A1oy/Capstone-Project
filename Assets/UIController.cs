using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static bool isPaused =false;

    public GameObject pauseMenu =null!;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
	{
        pauseMenu.SetActive(true);
		Time.timeScale = 0;
		isPaused = true;
	}
}
