using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 m_direction;
    Vector2 m_startPos;
    float m_endCoefficient;
    bool m_isSet =false;

    [SerializeField]
    float m_speed;

    void Update()
    {
        if (m_isSet)
        {
            float coeff = (new Vector2(transform.position.x, transform.position.y) -m_startPos)
                    .magnitude/m_endCoefficient;
            if (coeff>=1
                || coeff!=coeff)
            {
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(m_direction.x, m_direction.y, 0f)  *m_speed*Time.deltaTime;
    }

    public void Shoot(Vector2 direction, Vector2 startPos, Vector2 endPos)
    {
        m_direction =direction.normalized;
        m_startPos =startPos;
        m_endCoefficient = (endPos -startPos).magnitude;
        m_isSet=true;
    }
}
