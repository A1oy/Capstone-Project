using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonGas : MonoBehaviour
{
    float totalTime;
    private GameObject player;
    PlayerController playerScript;
    Vector2 cSize;
    Vector2 cOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        cOffset = GetComponent<BoxCollider2D>().offset;
        cSize = GetComponent<BoxCollider2D>().size;

        Vector3 direction = player.transform.position - transform.position;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg + 180;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

	void Update()
	{
        if (cOffset.x < 3)
		{
            if (totalTime < 0.4)
            {
                //LIMIT 3.7
                cOffset.x += 2.3f * Time.deltaTime;
            }
            else
            {
                cOffset.x += 1.9f * Time.deltaTime;
            }
            GetComponent<BoxCollider2D>().offset = cOffset;
        }

        if (cSize.x < 7)
        {
            if (totalTime < 0.4)
			{
                //LIMIT 7.45
                cSize.x += 5 * Time.deltaTime;
            }
			else
			{
                cSize.x += 4 * Time.deltaTime;
            }
            GetComponent<BoxCollider2D>().size = cSize;
        }

    }
}
