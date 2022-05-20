using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    bool particleCheck = true;

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("CheckParticle"))
        {
            //Debug.Log("+++++++ name : " + other.name + " tag : " + other.tag);
            if (!other.transform.parent.CompareTag(transform.tag))
            {
                particleCheck = false;
            }
        }
    }
}
