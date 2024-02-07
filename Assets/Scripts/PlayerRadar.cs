using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerRadar : MonoBehaviour
{
    Transform player;

    [SerializeField]
    float radius;

    [SerializeField]
    GameObject radar;

    [SerializeField]
    GameObject radarPlayer;

    float radarRadius;

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject hivePrefab;

    [SerializeField]
    float secondsDelay;

    float delay;

    List<GameObject> enemyPool;
    List<GameObject> hivePool;

    public void UpgradeDelay()
    {
        delay *=0.7f;
    }

    // Start is called before the first frame update
    void Awake()
    {
        delay =secondsDelay;
        player =GameObject.Find("FirePoint").transform;
        enemyPool =new List<GameObject>();
        hivePool =new List<GameObject>();
        radarRadius =radar.GetComponent<RectTransform>().rect.width/2.0f;
    }

    GameObject InstantiateObjectFromPool(List<GameObject> pool, GameObject prefab)
    {
        foreach (GameObject g in pool)
        {
            if (!g.activeInHierarchy)
            {
                return g;
            }
        }
        GameObject go =Instantiate(prefab, transform);
        pool.Add(go);
        return go;
    }

    void Update()
    {
        delay -=Time.deltaTime;
        if (delay <0f)
        {
            Image[] images =GetComponentsInChildren<Image>();
            foreach (Image image in images)
            {
                image.gameObject.SetActive(false);
            }
            const int layerMask=1<<9;
            Collider2D[] colliders =Physics2D.OverlapCircleAll(
                new Vector2(player.position.x, player.position.y),
                radius-1f,
                layerMask);

            foreach (Collider2D collider in colliders)
            {
                Vector2 dist =new Vector2(collider.gameObject.transform.position.x -player.position.x,
                    collider.gameObject.transform.position.y -player.position.y);
                dist = (dist/radius)*radarRadius;
                GameObject newPoint =InstantiateObjectFromPool(enemyPool, enemyPrefab);
                newPoint.GetComponent<RectTransform>().anchoredPosition =dist;
                newPoint.transform.eulerAngles = collider.transform.eulerAngles;

                newPoint.SetActive(true);
            }

            GameObject[] hives =GameObject.FindGameObjectsWithTag("Hive");
            foreach (GameObject hive in hives)
            {
                Vector2 dist =new Vector2(hive.transform.position.x -player.position.x,
                    hive.transform.position.y -player.position.y);
                if (dist.magnitude>radius)
                {
                    dist =dist.normalized*radarRadius;
                }
                else
                {
                    dist =(dist/radius)*radarRadius;
                }
                GameObject newPoint =InstantiateObjectFromPool(hivePool, hivePrefab);
                newPoint.GetComponent<RectTransform>().anchoredPosition =dist;

                newPoint.SetActive(true);
            }
            delay =secondsDelay;
        }
        else 
        {
            Image[] images =GetComponentsInChildren<Image>();
            foreach (Image image in images)
                image.color =new Color(1f, 1f, 1f, delay/secondsDelay);
        }
        radarPlayer.transform.rotation =player.rotation;
    }
    
    void OnDrawGizmos()
    {
        if (player)
        {
            // Draw a yellow sphere at the transform's position
            Color c = Color.yellow;
            c.a =0.5f;
            Gizmos.color = c;
            Gizmos.DrawSphere(player.position, radius);
        }
    }
}
