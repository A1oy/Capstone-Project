using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 m_direction;
    Vector2 m_startPos;
    bool m_isSet =false;

    [SerializeField]
    Rigidbody2D m_rb;

    [SerializeField]
    float m_speed;

    void Update()
    {
        if (m_isSet)
        {
            float coeff =(transform.position.x -m_startPos.x)/m_direction.x;
            if (coeff>=1)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Shoot(Vector2 direction, Vector2 startPos)
    {
        m_direction =direction;
        m_startPos =startPos;
        m_rb.AddForce(m_speed *m_direction, ForceMode2D.Impulse);
        m_isSet=true;
    }
}
