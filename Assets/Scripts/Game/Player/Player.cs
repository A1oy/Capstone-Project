using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Texture2D pixelTexture;
    private GUIStyle rectStyle;

    public int _honey=0;

    public Color color;

    void Start()
    {    
        pixelTexture = new Texture2D(1,1);
        pixelTexture.SetPixel(0, 0, color);
        pixelTexture.Apply();

        rectStyle = new GUIStyle();
        rectStyle.normal.background = pixelTexture;
    }

    public void GiveHoney(int honey)
    {
        _honey += honey;
    }

    void OnDestroy()
    {
        if (gameObject.GetComponent<Health>().isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
