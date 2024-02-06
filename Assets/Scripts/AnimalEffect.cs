using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEffect : MonoBehaviour
{
    private Health healthScript;

    private int burnDamage = 1;

    public List<int> burnTickTimers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
    }

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
            healthScript.health -= burnDamage;
            burnTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
