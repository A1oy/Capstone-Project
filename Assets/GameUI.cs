using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

#nullable enable

public class GameUI : MonoBehaviour
{
    public GameObject? baseRef;
    public GameObject? playerRef;
    public GameObject? turretRef;

    public TMP_Text baseHealth =null!;

    public TMP_Text playerHealth =null!;
    public TMP_Text playerHoney =null!;
    public TMP_Text cooldown =null!;

    public TMP_Text turret =null!;
    public TMP_Text turretText =null!;

    // Update is called once per frame

    void FixedUpdate()
    {
        if (baseRef)
        {
            baseHealth.text = Convert.ToString(baseRef!.GetComponent<Health>().health);
        }
        if (playerRef)
        {
            playerHealth.text =Convert.ToString(playerRef!.GetComponent<Health>().health);
            cooldown.text =Convert.ToString((int)playerRef!.GetComponent<Shooting>().cooldown) + " s";
            playerHoney.text = Convert.ToString(playerRef!.GetComponent<Player>()._honey);
        }
        if (turretRef)
        {
            turret.text =Convert.ToString((int)turretRef!.GetComponent<Health>().health);
        }
        else if (turretText
            && turretText.GetComponent<CanvasRenderer>().gameObject)
        {
            Destroy(turretText.GetComponent<CanvasRenderer>().gameObject);
            Destroy(turret.GetComponent<CanvasRenderer>().gameObject);
        }
    }
}
