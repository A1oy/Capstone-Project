using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoving : MonoBehaviour
{
    float speed =1.0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(-speed *Time.deltaTime, 0.0f, 0.0f);
    }
}
