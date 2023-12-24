using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverController : MonoBehaviour
{
    Vector3 prevPos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            prevPos =Input.mousePosition;
        }
        else if (Input.GetButton("Fire1"))
        {
            Vector3 delta =prevPos-Input.mousePosition;
            transform.position += delta *0.003f;
            prevPos =Input.mousePosition;
        }
    }
}
