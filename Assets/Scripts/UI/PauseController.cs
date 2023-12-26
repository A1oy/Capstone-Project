using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
	[SerializeField]
    GameObject pauseMenu;

	[SerializeField]
	GameObject settingsMenu;

	[SerializeField]
	GameObject pauseContainer;

	void OnEnable()
	{
		InputManager.input.Menu.CloseMenu.performed += OnClose;
	}

	void OnDisable()
	{
		InputManager.input.Menu.CloseMenu.performed -= OnClose;
	}

	void OnClose(InputAction.CallbackContext cc)
	{
		if (settingsMenu.activeInHierarchy)
		{
			settingsMenu.SetActive(false);
			pauseMenu.SetActive(true);
		}
		else {
			NetworkManager.GetLocalPlayer().GetComponent<PlayerController>().canMove =true;
			InputManager.ToggleActionMap(InputManager.input.Player);
			Resume();
		}
	}

	public void Pause()
	{
		pauseContainer.SetActive(true);
		Time.timeScale =0;
	}

	public void Resume()
	{
		pauseContainer.SetActive(false);
		Time.timeScale =1;
	}

	public void Restart()
	{
		SceneManager.LoadScene("Game");
		Time.timeScale =1;
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
