using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{

    [SerializeField]
    string m_startingScene;
    
    void Awake()
    {
        SceneManager.LoadScene(m_startingScene);
    }
}
