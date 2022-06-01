using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    Rigidbody rigid;
    bool inRange = true;
    public bool locked = true;

    AudioSource audioSource;
    [SerializeField]
    AudioClip LidOpenSound;
    [SerializeField]
    AudioClip LidCloseSound;

    [SerializeField]
    AudioClip collisionSound;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        grabable = GetComponent<PutCorrectionGrabable>();
        audioSource = GetComponent<AudioSource>();

        rigid.isKinematic = true;

        grabable.grabEndEvent.AddListener(GrabEnd);
        grabable.grabBeginEvent.AddListener(GrabBegin);
    }

    void GrabBegin()
    {
        locked = false;
        rigid.constraints = RigidbodyConstraints.None;
        rigid.useGravity = true;

        if(inRange)
            audioSource.PlayOneShot(LidOpenSound);
    }

    void GrabEnd()
    {
        if (inRange)
        {
            locked = true;
            rigid.useGravity = false;
            rigid.isKinematic = true;

            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.localPosition = Vector3.zero;

            audioSource.PlayOneShot(LidCloseSound);
        }
        else
        {
            rigid.isKinematic = false;
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
        if(other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            inRange = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            inRange = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(collisionSound);
    }
}