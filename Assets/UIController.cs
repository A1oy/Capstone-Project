using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private bool _isPaused =false;
    public  bool isMovement =true;

    public static UIController singleton =null!;
    public bool isPaused { set { PauseGame(value); } get { return _isPaused; }}

    public GameObject pauseMenu =null!;

    void Awake()
    {
        singleton =GetComponent<UIController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }

    void PauseGame(bool value)
    {
        _isPaused =value;
        isMovement =!value;
        Time.timeScale = _isPaused ? 0 :1;
    }
}
