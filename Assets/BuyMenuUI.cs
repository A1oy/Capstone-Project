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
    public GameObject player =null!;

    public TMP_Text grenadePriceText =null!;
    public TMP_Text honeyPriceText =null!;

    void Start()
    {
        playerComp =player.GetComponent<Player>();
        honeyPriceText.text = $"${honeyPrice}";
        grenadePriceText.text = $"${grenadePrice}";
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }

    public void SellHoney()
    {
        playerComp.honey --;
        playerComp.money+=honeyPrice;
    }

    public void BuyGrenade()
    {
        if (playerComp.money >=grenadePrice)
        {
            playerComp.money -= grenadePrice;
            playerComp.grenades ++;
        }
    }
}
