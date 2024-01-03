using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWinQuitToTitle : MonoBehaviour
{
    [SerializeField]
    TMP_Text m_score;

    GameplayManager gameplayManager;

    void Awake()
    {
        gameplayManager = GameObject.Find("GameplayManager").GetComponent<GameplayManager>();
        int score =gameplayManager.GetScore();
        m_score.text = Convert.ToString(score);
    }

    // Update is called once per frame
    public void OnQuitToTitleButtonClicked()
    {
        SceneManager.LoadScene("Main Menu"); 
        Destroy(gameplayManager.gameObject);
    }

    public void OnRestartGameButtonClicked()
    {
        SceneManager.LoadScene("Game"); 
        Destroy(gameplayManager.gameObject);
    }
}
