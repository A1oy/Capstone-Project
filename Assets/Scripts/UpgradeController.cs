using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera upgradeCam;

    [SerializeField]
    CinemachineVirtualCamera mainCam;

    [SerializeField]
    GameObject mainUi;

    [SerializeField]
    GameObject upgradeUi;

    [SerializeField]
    GameObject observer;

    public void OnEnable()
    {
        InputManager.input.Upgrade.CloseMenu.performed += OnClose;
    }

    public void OnDisable()
    {
        InputManager.input.Upgrade.CloseMenu.performed -= OnClose;
    }

    void OnClose(InputAction.CallbackContext cc)
    {
        CloseUpgrade();
        GameObject.Find("Player")
            .GetComponent<PlayerHoney>()
            .RefreshHoney();
    }

    void CloseUpgrade()
    {
        upgradeCam.Priority =0;
        upgradeUi.SetActive(false);

        mainCam.Priority =1;
        mainUi.SetActive(true);
        InputManager.ToggleActionMap(InputManager.input.Player);
        Time.timeScale =1;
        observer.SetActive(false);
        GameObject.Find("Player")
            .GetComponent<PlayerController>()
            .ReturnToMenu();
    }

    public void OpenUpgrade()
    {
        observer.SetActive(true);
        mainCam.Priority =0;
        mainUi.SetActive(false);

        upgradeCam.Priority =1;
        upgradeUi.GetComponent<UpgradeUIController>().UpdateHoney();
        upgradeUi.SetActive(true);
    }
}
