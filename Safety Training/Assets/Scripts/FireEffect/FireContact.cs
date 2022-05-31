using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireContact : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Fire"))
        {
            if(!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
