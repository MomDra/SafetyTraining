using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    bool inLidRange = true;
    public bool locked = true;

    AudioSource audioSource;

    private Transform lidPos;

    [SerializeField]
    AudioClip LidOpenSound;
    [SerializeField]
    AudioClip LidCloseSound;

    private void Start()
    {
        grabable = gameObject.GetComponent<PutCorrectionGrabable>();
        lidPos = transform;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //Debug.Log("lockChange: " + lockChange);
        if (grabable.isGrabbed)
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            locked = false;
        }
        else
        {
            //Debug.Log("    ---fixLoc");
            if (inLidRange)
            {
                if (!locked)
                {
                    if (!audioSource.isPlaying) audioSource.PlayOneShot(LidCloseSound);
                    transform.localPosition = new Vector3(0, 0, 0); 
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    locked = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) // ¿­±â
    {
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            inLidRange = false;
            if (!audioSource.isPlaying) audioSource.PlayOneShot(LidOpenSound);            
        }
    }

    private void OnTriggerEnter(Collider other) // ´Ý±â
    {
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            inLidRange = true;
        }
    }
}
