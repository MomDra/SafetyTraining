using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    bool lockChange = false;
    public bool locked = true;

    private void Start()
    {
        grabable = gameObject.GetComponent<PutCorrectionGrabable>();
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
            if (lockChange)
            {
                FixLid(transform.parent);
                locked = true;

            }
        }
    }

    private void FixLid(Transform _transform)
    {
        //Debug.Log("FixLid");
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            lockChange = false;
            locked = false;

            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (locked) return;
        if (other.CompareTag("LidCorrection") && other.transform == transform.parent.transform)
        {
            lockChange = true;
        }
    }
}
