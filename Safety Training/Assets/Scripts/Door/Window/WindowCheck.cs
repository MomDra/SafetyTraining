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
        if(y > 0)
        {
            y -= 360;
        }
        if (y < -20)// â�� ����
        {
            windowOpend = true;
        }
        else if (y < 0 && y >= -20) // â�� ����
        {
            windowOpend = false;
        }
    }
}
