using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpingLiquid : MonoBehaviour
{
    public ParticleSystem liquidParticle;
    public GameObject obj;
    private float fill;
    private float counter = 0.0f;
    private float size = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //size = transform.lossyScale[0];
        size = 0.3f;
        

    }

    // Update is called once per frame
    void Update()
    {

        Quaternion quaternion = transform.rotation;
        fill = obj.GetComponent<Renderer>().material.GetFloat("_Fill");
        //Debug.Log("fill : " + fill);
        //Debug.Log("size : " + size);

        float eulerX = quaternion[0] * quaternion[0] * 180;
        float eulerZ = quaternion[2] * quaternion[2] * 180;
        if (eulerX < 0) eulerX *= -1;
        if (eulerZ < 0) eulerZ *= -1;

        if ((eulerX > (90 - (fill * 90 / size))) || (eulerZ > (90 - (fill * 90 / size))))
        {
            if (fill >= -size)
            {
                fill -= 0.002f / size;
                obj.GetComponent<Renderer>().material.SetFloat("_Fill", fill);
                counter += 0.002f / size;
            }
        }

        if (counter > 0)
        {
            counter -= Time.deltaTime;
            
            liquidParticle.Play();
        }

    }
}
