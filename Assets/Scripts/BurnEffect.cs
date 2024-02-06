using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoBulletHit(GameObject go){
        if (go.CompareTag("Enemy")){
            if (go.GetComponent<AnimalEffect>() == null){
                    go.AddComponent<AnimalEffect>();
                }
                else{
                    go.GetComponent<AnimalEffect>().ResetBurn();
                }
        }
    }
}
