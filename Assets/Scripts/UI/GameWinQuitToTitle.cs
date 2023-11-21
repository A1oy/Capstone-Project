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
        m_score.text = Convert.ToString(NetworkManager.GetLocalPlayer().GetComponent<PlayerInventory>().GetScore());
    }

    // Update is called once per frame
    public void OnQuitToTitleButtonClicked()
    {
        SceneManager.LoadScene("Main Menu"); 
    }
}
