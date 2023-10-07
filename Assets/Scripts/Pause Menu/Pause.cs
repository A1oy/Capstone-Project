using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu =null!;
	public GameObject settingsMenu =null!;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Resume();
		}
	}

	void OnEnable()
	{
		settingsMenu.SetActive(false);
	}

	public void Resume()
	{
		gameObject.SetActive(false);
		Time.timeScale = 1;
		UIController.isPaused = false;
	}

	public void Restart()
	{
		SceneManager.LoadScene("Game");
		Time.timeScale = 1;
	}

	public void Settings()
	{
		pauseMenu.SetActive(false);
		settingsMenu.SetActive(true);
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
