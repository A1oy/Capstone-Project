using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Texture2D pixelTexture;
    private GUIStyle rectStyle;

    public int playerExp=0;

    public Color color;

    void Start()
    {    
        pixelTexture = new Texture2D(1,1);
        pixelTexture.SetPixel(0, 0, color);
        pixelTexture.Apply();

        rectStyle = new GUIStyle();
        rectStyle.normal.background = pixelTexture;
    }

    public void AddExp(int exp)
    {
        playerExp += exp;
        while (playerExp >= 20)
        {
            Shooting shooting = gameObject.GetComponent<Shooting>();
            shooting.baseDamage ++;
            playerExp -=20;
        }
    }

    void OnDestroy()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
