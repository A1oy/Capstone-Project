using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private bool _isPaused =false;

    [System.NonSerialized]
    public  bool isMovement =true;

    public static MenuManager singleton =null!;
    public bool isPaused { set { PauseGame(value); } get { return _isPaused; }}

    public GameObject pauseMenu =null!;

    void Awake()
    {
        singleton =GetComponent<MenuManager>();
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
