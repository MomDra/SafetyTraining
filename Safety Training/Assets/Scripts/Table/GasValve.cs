using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : MonoBehaviour
{
    //public float x;
    public bool gasLocked = true;
    public float x;


    //public InputHelpers.Button activationButton;
    public float activationThreshold = 0.1f;

    private float timer = 0f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        x = transform.localEulerAngles.x;
        //y = transform.localEulerAngles.y;
        //z = transform.localEulerAngles.z;


        Debug.Log("손잡이 각도(x): (" + x + ")" + gasLocked);

        
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
