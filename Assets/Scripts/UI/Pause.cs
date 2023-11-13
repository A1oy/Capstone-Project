using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu =null!;
	public GameObject settingsMenu =null!;

	[SerializeField]
	private GameObject pauseContainer;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameObject.SetActive(false);
			pauseMenu.SetActive(true);
		}
	}

	void OnEnable()
	{
		settingsMenu.SetActive(false);
		MenuManager.singleton!.isPaused =true;
		pauseContainer.SetActive(true);
	}

	void OnDisable()
	{
		MenuManager.singleton!.isPaused =false;
		pauseContainer.SetActive(false);
	}

	public void Resume()
	{
		gameObject.SetActive(false);
	}

	public void Restart()
	{
		SceneManager.LoadScene("Game");
		MenuManager.singleton!.isPaused =false;
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
