using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFall : MonoBehaviour
{
    ParticleSystem liquidParticle;
    public static bool activeFlag = false;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        liquidParticle = GetComponent<ParticleSystem>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (activeFlag)
        {
            liquidParticle.Play();
            if (timer > 5) timer = 0;
        }
        else
        {
            liquidParticle.Pause();
            liquidParticle.Clear();
        }
    }
}
