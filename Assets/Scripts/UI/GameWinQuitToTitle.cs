using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWinQuitToTitle : MonoBehaviour
{
    TMP_Text m_score; //dont serialize

    void Awake()
    {
        m_score.text = Convert.ToString(NetworkManager.GetLocalPlayer().GetComponent<PlayerInventory>().GetScore());
        Destroy(NetworkManager.GetLocalPlayer()); 
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
