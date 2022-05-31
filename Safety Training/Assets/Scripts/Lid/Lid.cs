using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    bool inRange = true;
    public bool locked = true;
    bool closeHasPlayed = true;

    AudioSource audioSource;
    [SerializeField]
    AudioClip LidOpenSound;
    [SerializeField]
    AudioClip LidCloseSound;

    private void Start()
    {
        grabable = gameObject.GetComponent<PutCorrectionGrabable>();
        FixLid(transform.parent);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (grabable.isGrabbed)
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (locked && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(LidOpenSound);
            }
            locked = false;
            
        }
        else
        {
            if (inRange)
            {
                FixLid(transform.parent);
                if (!locked && !audioSource.isPlaying && !closeHasPlayed)
                {
                    audioSource.PlayOneShot(LidCloseSound);
                    closeHasPlayed = true;
                }
                locked = true;
            }
        }
    }

    private void FixLid(Transform _transform)
    {
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            Debug.Log("curr : " + transform.name + ", coll : " + other.name);
            locked = false;
            closeHasPlayed = false;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (locked) return;
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            inRange = true;
        }
    }
}