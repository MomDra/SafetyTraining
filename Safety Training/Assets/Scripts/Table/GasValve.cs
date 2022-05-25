using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : MonoBehaviour
{
    public bool gasLocked = true;
    public float x;

    //private float timer = 0f;
    
    // Update is called once per frame
    void Update()
    {
        x = transform.localEulerAngles.x;

        if (x > 20)// 가스 벨브 열림
        {
            gasLocked = false;
        }
        else if (x > 0 && x <= 20) // 가스 벨브 닫힘
        {
            gasLocked = true;
        }
    }
}
