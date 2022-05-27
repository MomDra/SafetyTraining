using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCheck : MonoBehaviour
{
    public bool windowOpend = false;
    public float y;

    //private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        y = transform.localEulerAngles.y;
        Debug.Log("y : " + y);
        if(y > 0)
        {
            y -= 360;
            Debug.Log("-y : " + y);
        }
        if (y < -20)// Ã¢¹® ¿­¸²
        {
            windowOpend = true;
            Debug.Log("window : "+ windowOpend);
        }
        else if (y < 0 && y >= -20) // Ã¢¹® ´ÝÈû
        {
            windowOpend = false;
            Debug.Log("window : " + windowOpend);
        }
    }
}
