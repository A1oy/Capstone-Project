using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public float speed = 5f;
    Vector2 movement;
    Vector2 mousePos;

    [SerializeField]
    AudioSource walkingSource;
    
    // Update every frame
    void FixedUpdate()
    {
        walkingSource.volume =AudioManager.instance.GetSfxVolume();

        if (MenuManager.singleton!.isMovement)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (movement.x!=0
                || movement.y!=0)
            {
                if (!walkingSource.isPlaying)
                {
                    walkingSource.Play();
                }
            }
            else
            {
                if (walkingSource.isPlaying)
                {
                    walkingSource.Stop();
                }
            }
        }
        else
        {
            if (walkingSource.isPlaying)
            {
                walkingSource.Stop();
            }
            movement.x =0;
            movement.y =0;
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.velocity = movement * speed;
        Vector2 lookDir = mousePos - rb.position;

        //Finding angle using atan2 function
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
