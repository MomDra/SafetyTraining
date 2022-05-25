using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : MonoBehaviour
{
    public bool gasLocked = true;
    public float x;

    public float activationThreshold = 0.1f;

    private float timer = 0f;
    // Start is called before the first frame update
    
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
