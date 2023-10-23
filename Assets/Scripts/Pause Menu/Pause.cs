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
			gameObject.SetActive(false);
		}
	}

	void OnEnable()
	{
		settingsMenu.SetActive(false);
		UIController.singleton!.isPaused =true;
	}

	void OnDisable()
	{
		UIController.singleton!.isPaused =false;		
	}

	public void Restart()
	{
		SceneManager.LoadScene("Game");
		UIController.singleton!.isPaused =false;
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
