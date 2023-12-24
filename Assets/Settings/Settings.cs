using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject pauseMenu =null!;
    
    public void Done()
    {
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
