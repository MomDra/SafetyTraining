using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCollisionSound : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    AudioClip clip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bottle"))
        {
            if(!source.isPlaying)
                source.PlayOneShot(clip);
        }
    }
}
