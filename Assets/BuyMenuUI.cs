using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyMenuUI : MonoBehaviour
{
    Player playerComp;

    public int grenadePrice =2;
    public int honeyPrice =1;
    public int maxGrenades =2;
    public GameObject player =null!;

    [SerializeField]
    private GameObject buyContainer;
    

    public TMP_Text grenadePriceText =null!;
    public TMP_Text honeyPriceText =null!;

    void Start()
    {
        playerComp =player.GetComponent<Player>();
    }

    void OnEnable()
    {
        MenuManager.singleton!.isMovement =false;
        honeyPriceText.text = $"${honeyPrice}";
        grenadePriceText.text = $"${grenadePrice}";
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

    public void SellHoney()
    {
        if (playerComp.honey >0)
        {
            playerComp.honey --;
            playerComp.money+=honeyPrice;
        }
    }

    public void BuyGrenade()
    {
        if (playerComp.money >=grenadePrice
            && playerComp.grenades <maxGrenades)
        {
            playerComp.money -= grenadePrice;
            playerComp.grenades ++;
        }
    }
}
