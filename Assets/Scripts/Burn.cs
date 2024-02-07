using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
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
        }
    }

    public void ResetBurn(){
        currentBurnTimer = 0f;
    }

    /*
    public void ApplyBurn(int ticks)
    {
        if(burnTickTimers.Count<=0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }
    
    IEnumerator Burn()
    {
        while(burnTickTimers.Count>0)
        {
            for(int i = 0; i<burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            healthScript.DoDamage(burnDamage);
            burnTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
    */
}
