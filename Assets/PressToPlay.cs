using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToPlay : MonoBehaviour
{
    [SerializeField]
    GameObject pauseController;

    [SerializeField]
    GameObject upgradeController;

    [SerializeField]
    GameObject pressToPlay;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject fakePlayer;

    void OnEnable()
    {
        Time.timeScale =0;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            upgradeController.SetActive(true);
            pauseController.SetActive(true);
            Time.timeScale=1;
            fakePlayer.SetActive(false);
            player.SetActive(true);
            pressToPlay.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
