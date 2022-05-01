using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFall : MonoBehaviour
{
    ParticleSystem liquidParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        liquidParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (DumpingLiquid.counter > 0) Debug.Log(DumpingLiquid.counter);
        /*if(DumpingLiquid.counter > 0)
        {
            DumpingLiquid.counter -= Time.deltaTime;
            liquidParticle.Play();
        }*/
        /*else
        {
            liquidParticle.Pause();
            liquidParticle.Clear();
        }*/
        
    }
}
