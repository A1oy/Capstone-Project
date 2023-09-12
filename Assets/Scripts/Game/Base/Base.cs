using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    private Texture2D pixelTexture;
    private GUIStyle rectStyle;
    private Health baseHealth;

    public Color color;

    void Start()
    {    
        pixelTexture = new Texture2D(1,1);
        pixelTexture.SetPixel(0, 0, color);
        pixelTexture.Apply();

        rectStyle = new GUIStyle();
        rectStyle.normal.background = pixelTexture;
        baseHealth =gameObject.GetComponent<Health>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 50, 20), "Base Health");
        GUI.Label(new Rect(110, 30, 100, 20),  Convert.ToString(baseHealth.health, 10));
    }

    void OnDestroy()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
