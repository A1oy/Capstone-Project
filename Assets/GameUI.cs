using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameUI : MonoBehaviour
{
    public GameObject baseRef;
    public GameObject playerRef;
    public GameObject turretRef;

    public TMP_Text baseHealth;
    public TMP_Text playerHealth;
    public TMP_Text playerEXP;
    public TMP_Text cooldown;
    public TMP_Text turret;

    // Update is called once per frame
    void FixedUpdate()
    {
        baseHealth.text = Convert.ToString(baseRef.GetComponent<Health>().health);
        playerHealth.text =Convert.ToString(playerRef.GetComponent<Health>().health);
        playerEXP.text =Convert.ToString(playerRef.GetComponent<Player>().playerExp) + " / " + "20";
        cooldown.text =Convert.ToString((int)playerRef.GetComponent<Shooting>().cooldown) + " s";
        turret.text =Convert.ToString((int)turretRef.GetComponent<Health>().health);
    }
}
