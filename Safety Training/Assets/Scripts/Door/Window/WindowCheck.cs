using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCheck : MonoBehaviour
{
    public bool windowOpend = false;
    public float y;

    bool isTrigger;

    //private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        y = transform.localEulerAngles.y;
        if(y > 0)
        {
            y -= 360;
        }

         if (y < 0 && y >= -20) // Ã¢¹® ´ÝÈû
         {
            windowOpend = false;

            if (!isTrigger)
            {
                isTrigger = true;
                GameManager.Instance.EmergencyManager.IsOpenedWindow = false;
            }
            
         }
         else if (y < -20)// Ã¢¹® ¿­¸²
         {
            windowOpend = true;

            if (isTrigger)
            {
                isTrigger = false;
                GameManager.Instance.EmergencyManager.IsOpenedWindow = true;
            }
         }
        
    }
}
