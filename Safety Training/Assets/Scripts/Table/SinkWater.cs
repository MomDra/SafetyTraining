using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkWater : MonoBehaviour
{
    public ParticleSystem sinkWater;
    public float x;
    //public float y;
    //public float z;


    //public InputHelpers.Button activationButton;
    public float activationThreshold = 0.1f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //sinkWater = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.localEulerAngles.x;
        //y = transform.localEulerAngles.y;
        //z = transform.localEulerAngles.z;
        
        
        //Debug.Log("손잡이 각도(x,y,z): (" + x + ", " + y + ", " + z + ")");


        if (x > 1.5)
        {
            sinkWater.Play();
        }
        else if (x < 2 && x > 0 || x > 21 && x <= 180)
        {
            sinkWater.Pause();
            sinkWater.Clear();
        }
    }
}