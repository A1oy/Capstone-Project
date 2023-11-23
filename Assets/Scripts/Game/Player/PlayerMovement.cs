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

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite[] playerSprites;

    [SerializeField]
    Transform rotateView;

    void Awake()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        UpdatePlayerSprite(angle);
    }

    void UpdateMovementAudio()
    {
        if (MenuManager.singleton!.isMovement)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (movement.x!=0 || movement.y!=0)
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
    }

    void UpdatePlayerSprite(float angleLookAt)
    {
        angleLookAt-=45f;
        if (angleLookAt<0f)
        {
            angleLookAt+=360;
        }
        angleLookAt *=1f/90f;
        spriteRenderer.sprite =playerSprites[(int)angleLookAt];
    }
    
    // Update every frame
    void Update()
    {
        UpdateMovementAudio();
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.velocity = movement * speed;
        Vector2 lookDir = mousePos - rb.position;

        //Finding angle using atan2 function
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rotateView.rotation = Quaternion.Euler(0f, 0f, angle);;

        UpdatePlayerSprite(angle);
    }
}
