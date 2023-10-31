using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyMenuUI : MonoBehaviour
{
    Player playerComp;

    public GameObject player =null!;

    [SerializeField]
    private GameObject buyContainer;
    

    void Start()
    {
        playerComp =player.GetComponent<Player>();
    }

    void OnEnable()
    {
        MenuManager.singleton!.isMovement =false;
        buyContainer.SetActive(true);
    }
    
    void OnDisable()
    {
        MenuManager.singleton!.isMovement =true;
        buyContainer.SetActive(false);
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
