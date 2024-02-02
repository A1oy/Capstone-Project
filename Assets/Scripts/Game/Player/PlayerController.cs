using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Skunk's poison related
    bool poisonStatus = false;
    float tickRate = 1.5f;
    float poisonTime = 6.1f;
    enum PlayerMovementState
    {
        Normal,
        Eating,
        InMenu
    };

    public Rigidbody2D rb;
    Camera cam;

    [SerializeField]
    PlayerMovementState state = PlayerMovementState.Normal;
    
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float eatingSpeed =0.01f;

    float playerSpeed;

    Vector2 movement;
    Vector2 mousePos;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite[] playerSprites;

    [SerializeField]
    Transform rotateView;

    PauseController pauseController;
    UpgradeController upgradeController;

    [SerializeField]
    PlayerHoney playerHoney;

    [SerializeField]
    WalkingFX walkingfx;

    PlayerUIController uiController;

    void OnEnable()
    {
        InputManager.ToggleActionMap(InputManager.input.Player);
        InputManager.input.Player.Upgrade.performed += OnUpgrade;
        InputManager.input.Player.EscapeToMenu.performed += OnEscapeToMenu;
        InputManager.input.Player.Eating.performed += OnEating;
        InputManager.input.Player.Eating.canceled += OnEatingCancelled;
        InputManager.input.Player.Walking.performed += OnWalking;
        InputManager.input.Player.Walking.canceled += OnWalkingCancelled;

        walkingfx =GetComponent<WalkingFX>();

        pauseController =GameObject.Find("PauseController").GetComponent<PauseController>();
        upgradeController =GameObject.Find("UpgradeController").GetComponent<UpgradeController>();
        uiController =GameObject.Find("PlayerUI").GetComponent<PlayerUIController>();
    }

    void OnDisable()
    {
        InputManager.input.Player.Upgrade.performed -= OnUpgrade;
        InputManager.input.Player.EscapeToMenu.performed -= OnEscapeToMenu;

        InputManager.input.Player.Eating.performed -= OnEating;
        InputManager.input.Player.Eating.canceled -= OnEatingCancelled;
        InputManager.input.Player.Disable();
    }

    void OnUpgrade(InputAction.CallbackContext cc)
    {
        state = PlayerMovementState.InMenu;
        InputManager.ToggleActionMap(InputManager.input.Upgrade);
        Time.timeScale =0;
        upgradeController.OpenUpgrade();
    }

    void OnEscapeToMenu(InputAction.CallbackContext cc)
    {
        state = PlayerMovementState.InMenu;
        InputManager.ToggleActionMap(InputManager.input.Menu);
        pauseController.Pause();
    }

    void OnEating(InputAction.CallbackContext cc)
    {
        if (state != PlayerMovementState.InMenu)
        {
            playerSpeed =eatingSpeed;
            state = PlayerMovementState.Eating;
            playerHoney.StartEating();
        }
    }

    void OnEatingCancelled(InputAction.CallbackContext cc)
    {
        if (state == PlayerMovementState.Eating)
        {
            playerSpeed =speed;
            state = PlayerMovementState.Normal;
            playerHoney.StopEating();
        }
    }

    void OnWalking(InputAction.CallbackContext cc)
    {
        walkingfx.StartWalking();
    }

    void OnWalkingCancelled(InputAction.CallbackContext cc)
    {
        walkingfx.StopWalking();
    }

    void Awake()
    {
        cam =GameObject.Find("Main Camera").GetComponent<Camera>();
        playerSpeed = speed;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        UpdatePlayerSprite(angle);
    }

    public void ReturnToMenu()
    {
        state =PlayerMovementState.Normal;
    }

    void UpdateMovementAudio()
    {
        if (state != PlayerMovementState.InMenu)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
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
        const float reduce =1f/90f;
        int index =(int)(angleLookAt*reduce);
        spriteRenderer.sprite = index>3 ? playerSprites[3] : playerSprites[index];
    }
    
    // Update every frame
    void Update()
    {
        UpdateMovementAudio();
        
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        rb.velocity = movement * playerSpeed;
        Vector2 lookDir = mousePos - rb.position;

        //Finding angle using atan2 function
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rotateView.rotation = Quaternion.Euler(0f, 0f, angle);

        if (state != PlayerMovementState.InMenu)
        {
            UpdatePlayerSprite(angle);
            uiController.UpdateRadarRotation(Quaternion.Euler(0f, 0f, angle));
        }

        if (poisonStatus)
        {
            if (poisonTime > 0f)
            {
                poisonTime -= Time.deltaTime;
                tickRate -= Time.deltaTime;
                if (tickRate <= 0f)
                {
                    tickRate = 1.5f;
                    GetComponent<Health>().DoDamage(1);
                }
            }
            else
            {
                poisonStatus = false;
                poisonTime = 6.1f;
            }
        }
    }

    public bool Move()
    {
        return state != PlayerMovementState.InMenu;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Poison"))
		{
            poisonStatus = true;
            poisonTime = 6.1f;
        }
    }
}
