using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public bool wrongWasteFluidPass = true;
    public bool ExpirationDate = true;
    public bool wasteFluidPass = true;
    private int particleCnt = 0;

    private void Start()
    {
        if (!ExpirationDate)
        {
            wasteFluidPass = false;
        }
    }

    private void Update()
    {
        if (particleCnt > 100 && transform.parent.gameObject.GetComponent<Renderer>().material.GetFloat("_Fill") < -0.55)
        {
            wasteFluidPass = true;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("CheckParticle"))
        {
            //Debug.Log("+++++++ name : " + other.name + " tag : " + other.tag);
            if (!other.transform.parent.CompareTag(transform.tag))
            {
                wrongWasteFluidPass = false;
            }
            else if(!ExpirationDate)
            {
                particleCnt++;
                Debug.Log("particleCnt: " + particleCnt);
            }
        }
    }
}
