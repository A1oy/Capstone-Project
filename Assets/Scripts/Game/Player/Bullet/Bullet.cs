using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 m_direction;
    Vector2 m_startPos;
    float m_endCoefficient;

    [SerializeField]
    float m_speed;

    [SerializeField]
    AudioClip m_obstacleHitClip;

    [SerializeField]
    AudioClip m_enemyHitClip;

    void FixedUpdate()
    {
        float coeff = (new Vector2(transform.position.x, transform.position.y) -m_startPos)
                .magnitude/m_endCoefficient;
        if (coeff>=1
            || coeff!=coeff)
        {
            Destroy(gameObject);
        }
        transform.position += m_direction  *m_speed*Time.deltaTime;
    }

    public void Init(Vector3 direction, Vector2 startPos, Vector2 endPos, bool isEnemy)
    {
        m_direction =direction.normalized;
        m_direction.z = 0f;

        m_startPos =startPos;
        m_endCoefficient = (endPos -startPos).magnitude;
        gameObject.SetActive(true);

        AudioManager.instance.PlaySoundEffect(isEnemy ? m_enemyHitClip : m_obstacleHitClip);
    }
}
