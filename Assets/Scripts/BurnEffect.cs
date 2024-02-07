using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : MonoBehaviour
{
    public PlayerData player;
    public GameObject burnfx;
    
    public void DoBulletHit(GameObject go){
        if (go.CompareTag("Enemy")){
            
            if (go.GetComponent<Burn>() == null){
                    Burn burn =go.AddComponent<Burn>();
                    GameObject burnEff = Instantiate(burnfx, go.transform, false);
                    burn.player =player;
                    burn.burnEff =burnEff;
                    
                }
                else{
                    go.GetComponent<Burn>().ResetBurn();
                }
        }
    }
}
