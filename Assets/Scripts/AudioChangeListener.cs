using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChangeListener : MonoBehaviour
{
   void Awake()
   {
        AudioManager.instance.SetRoot(gameObject);
   }

   void Destroy()
   {
        AudioManager.instance.ClearRoot();
   }
}
