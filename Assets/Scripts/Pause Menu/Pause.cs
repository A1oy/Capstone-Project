using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
	public static bool isPaused;

	void Start()
	{
		pauseMenu.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				Resume();
			}
			else
			{
				PauseGame();
			}
		}
	}
	public void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
		isPaused = true;
	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;
	}

	public void Restart()
	{
		SceneManager.LoadScene("Game");
		Time.timeScale = 1;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Main Menu");
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
