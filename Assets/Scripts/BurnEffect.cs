using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : MonoBehaviour
{
    public void DoBulletHit(GameObject go){
        if (go.CompareTag("Enemy")){
            
            if (go.GetComponent<Burn>() == null){
                    go.AddComponent<Burn>();
                }
                else{
                    go.GetComponent<Burn>().ResetBurn();
                }
        }
    }
}
