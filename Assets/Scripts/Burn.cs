using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    public PlayerData player;
    public GameObject burnEff;
    private Health healthScript;

    private int burnDamage = 1;
    private float burnTimer = 2f;
    private float currentBurnTimer = 0f;
    private float burnEverySec = 0.4f;
    private float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    void Update(){
        cooldown += Time.deltaTime;
        if (cooldown >= burnEverySec){
            cooldown = 0;
            healthScript.DoDamage(burnDamage);
        }
        currentBurnTimer += Time.deltaTime;
        if (currentBurnTimer >= burnTimer){
            Destroy(this);
            SendMessage("OnBurnOut", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void ResetBurn(){
        currentBurnTimer = 0f;
    }

    public void OnDead()
    {
        Destroy(this);
    }

    void OnDestroy()
    {
        Destroy(burnEff);
    }
}
