using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonGas : MonoBehaviour
{
    private GameObject player;
    PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();

        Vector3 direction = player.transform.position - transform.position;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(rot, -90, 0);
    }

    void OnParticleTrigger(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript.poison();
        }
    }
}
