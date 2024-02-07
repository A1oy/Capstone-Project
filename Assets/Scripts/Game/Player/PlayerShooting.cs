using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{   

    [SerializeField]
    public PlayerData player;

    [SerializeField]
    PlayerController controller;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float grenadeCooldownInSeconds;

    float grenadeCooldown;

    [SerializeField]
    GameObject grenadePrefab;

    [SerializeField]
    int numShootPerFrames;

    int curShootFrame =0;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    AudioSource shootSfx;

    List<PostShotBehaviourCommand> psbcs = new List<PostShotBehaviourCommand>();
    List<ShotBehaviourCommand> sbcs = new List<ShotBehaviourCommand>();

    void OnEnable()
    {
        InputManager.input.Player.ThrowGrenade.performed +=OnThrowGrenade;
    }

    void OnDisable()
    {
        InputManager.input.Player.ThrowGrenade.performed -= OnThrowGrenade;
    }

    void OnThrowGrenade(InputAction.CallbackContext cc)
    {
        if (grenadeCooldown>= grenadeCooldownInSeconds)
        {
            grenadeCooldown =0f;
            GameObject grenade =Instantiate(grenadePrefab, firePoint.transform.position, Quaternion.identity);
            grenade.GetComponent<Rigidbody2D>().AddForce(firePoint.up *5f, ForceMode2D.Impulse);
        }
    }


    void FixedUpdate()
    {
        if (grenadeCooldown<grenadeCooldownInSeconds)
        {
            grenadeCooldown +=Time.deltaTime;
        }
        if (controller.Move())
		{
            curShootFrame++;
            if (curShootFrame==numShootPerFrames)
            {
                curShootFrame=0;
                if (Input.GetButton("Fire1"))
                {
                    Shoot();
                }
            }
          
        }
    }

    public T? GetShotBehaviourCommand<T>() where T : ShotBehaviourCommand
    {
        foreach(ShotBehaviourCommand sbc in sbcs)
        {
            if (sbc.GetType() ==typeof(T))
            {
                return (T)sbc;
            }
        }
        return null;
    }


    public void AddShotBehaviourCommand(ShotBehaviourCommand sbc)
    {
        sbcs.Add(sbc);
        sbcs.Sort(); 
    }

    public void AddPostShotBehaviourCommand(PostShotBehaviourCommand psbc)
    {
        psbcs.Add(psbc);
        psbcs.Sort(); 
    }

    public void Shoot()
    {
        List<GameObject> bullets = new List<GameObject> { }; 
        bullets.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));

        foreach(ShotBehaviourCommand sbc in sbcs) {
            sbc.Execute(firePoint, bulletPrefab, bullets); 
        }

        foreach(PostShotBehaviourCommand psbc in psbcs) {
            foreach(GameObject bullet in bullets) {
                psbc.Apply(bullet);
            }
        }

        foreach(GameObject bullet in bullets) {
            bullet.SetActive(true);
        }
        bullets.Clear();
    }
}