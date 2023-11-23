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

    void Awake()
    {
        int score =NetworkManager.GetLocalPlayer().GetComponent<PlayerInventory>().GetScore();
        Destroy(NetworkManager.GetLocalPlayer());
        m_score.text = Convert.ToString(score);
    }

    // Update is called once per frame
    public void OnQuitToTitleButtonClicked()
    {
        SceneManager.LoadScene("Main Menu"); 
    }

    public void OnRestartGameButtonClicked()
    {
        SceneManager.LoadScene("Game"); 
        
    }
}
