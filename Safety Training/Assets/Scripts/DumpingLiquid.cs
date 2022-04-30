using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpingLiquid : MonoBehaviour
{
    public GameObject obj;
    private float fill;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion quaternion = transform.rotation;
        fill = obj.GetComponent<Renderer>().material.GetFloat("_Fill");
        //Debug.Log("fill : " + fill);
        float eulerX = quaternion[0] * quaternion[0] * 180;
        float eulerZ = quaternion[2] * quaternion[2] * 180;
        if (eulerX < 0) eulerX *= -1;
        if (eulerZ < 0) eulerZ *= -1;

        if ((eulerX > (90 - (fill * 90))) || (eulerZ > (90 - (fill * 90))))
        {
            if (fill > -1)
            {
                LiquidFall.activeFlag = true;
                fill -= 0.01f;
                obj.GetComponent<Renderer>().material.SetFloat("_Fill", fill);
            }
        }
        else LiquidFall.activeFlag = false;
        Debug.Log(LiquidFall.activeFlag);
    }
}
