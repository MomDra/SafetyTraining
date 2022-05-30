using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LidTmp : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    bool inLidRange = true;
    public bool locked = true;

    AudioSource audioSource;
    Rigidbody rb;

    [SerializeField]
    AudioClip LidOpenSound;
    [SerializeField]
    AudioClip LidCloseSound;

    private void Start()
    {
        grabable = transform.GetComponent<PutCorrectionGrabable>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Debug.Log("lockChange: " + lockChange);
        if (grabable.isGrabbed)
        {
            rb.constraints = RigidbodyConstraints.None;
            locked = false;
        }
        else
        {
            //Debug.Log("    ---fixLoc");
            if (inLidRange)
            {
                if (!locked)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    locked = true;
                    if (!audioSource.isPlaying) audioSource.PlayOneShot(LidCloseSound);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) // ¿­±â
    {
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            inLidRange = false;
            gameObject.transform.parent = null;
            if (!audioSource.isPlaying) audioSource.PlayOneShot(LidOpenSound);
        }
    }

    private void OnTriggerEnter(Collider other) // ´Ý±â
    {
        if (other.CompareTag("LidCorrection") && !other.transform.parent.GetComponent<DumpingLiquid>().lid)
        {
            inLidRange = true;
            transform.SetParent(other.transform);
        }
    }
}
