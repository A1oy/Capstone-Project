using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.NonSerialized]
    public bool isEnabled =true;

    [System.NonSerialized]
    public bool isInteracting =false;

    public float touchRadius =2.0f;

    public string text;

    [SerializeField]
    bool m_setText;

    void FixedUpdate()
    {
        Collider2D collision =Physics2D.OverlapCircle(gameObject.transform.position, touchRadius, 1<<7);
        if (collision)
        {
            if (!isInteracting
                && isEnabled)
            {
                isInteracting =true;
                gameObject.SendMessage("OnInteract", collision.gameObject, SendMessageOptions.DontRequireReceiver);
                if (m_setText)
                {
                    InteractController.singleton!.text =text;
                }
            }
        }
        else
        {
            if (isInteracting)
            {
                isInteracting =false;
                if (m_setText)
                {
                    InteractController.singleton!.text =null;
                }
                gameObject.SendMessage("OnLeaveInteract", SendMessageOptions.DontRequireReceiver);
            }
        }
        if (!isEnabled
            && isInteracting)
        {
            gameObject.SendMessage("OnLeaveInteract", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.anyKeyDown
            && isEnabled
            && isInteracting)
        {
            gameObject.SendMessage("OnInteracting", SendMessageOptions.DontRequireReceiver);
        }
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