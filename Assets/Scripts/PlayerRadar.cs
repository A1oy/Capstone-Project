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

    List<GameObject> enemyPool;

    // Start is called before the first frame update
    void Awake()
    {
        player =NetworkManager0.GetLocalPlayer().transform;
        enemyPool =new List<GameObject>();
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
        Image[] images =GetComponentsInChildren<Image>();
        foreach (Image image in images)
            image.gameObject.SetActive(false);

        const int layerMask=1<<9;
        Collider2D[] colliders =Physics2D.OverlapCircleAll(
            new Vector2(player.position.x, player.position.y),
            radius-1f,
            layerMask);

        foreach (Collider2D collider in colliders)
        {

            Vector2 dist =new Vector2(collider.gameObject.transform.position.x -player.position.x,
                collider.gameObject.transform.position.y -player.position.y);
            Vector2 prevd =dist;
            dist = (dist/radius)*radarRadius;
            GameObject newPoint =InstantiateObjectFromPool(enemyPool, enemyPrefab);
            newPoint.GetComponent<RectTransform>().anchoredPosition =dist;
            newPoint.transform.eulerAngles = collider.transform.eulerAngles;

            newPoint.SetActive(true);
        }
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
