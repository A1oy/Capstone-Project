using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.NonSerialized]
    public bool isEnabled =true;

    public float touchRadius =2.0f;

    [SerializeField]
    string text;

    [SerializeField]
    bool m_setText;

    bool m_isInteracting=false;

    void FixedUpdate()
    {
        Collider2D collision =Physics2D.OverlapCircle(gameObject.transform.position, touchRadius, 1<<7);

        bool newState =IsInteracting(collision);

        if (m_isInteracting!=newState)
        {
            m_isInteracting =newState;
            if (m_isInteracting)
            {
                gameObject.SendMessage("OnInteract", collision.gameObject, SendMessageOptions.DontRequireReceiver);
                if (m_setText)
                {
                    InteractController.singleton!.text =text;
                }
            }
            else
            {
                gameObject.SendMessage("OnLeaveInteract", SendMessageOptions.DontRequireReceiver);
                if (m_setText)
                {
                    InteractController.singleton!.text =null;
                }
            }
        }
        else
        {
            if (m_isInteracting)
            {
                gameObject.SendMessage("OnInteracting", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    bool IsInteracting(Collider2D collision)
    {
        return collision!=null && isEnabled;
    }

    void OnDaylightChange(bool isDayTime)
    {
        isEnabled =isDayTime;
    }

    void OnDrawGizmos()
    {
        Gizmos.color =new Color(1.0f, 1.0f, 0.6f, 0.3f);
        Gizmos.DrawSphere(transform.position, touchRadius);
    }
}