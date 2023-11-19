using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinQuitToTitle : MonoBehaviour
{

    //When the scene is loaded 
    private void Awake()
    {
        //play the soundtrack

    }

    // Update is called once per frame
    public void OnQuitToTitleButtonClicked()
    {
        SceneManager.LoadSceneAsync("Main Menu"); 
    }
}
