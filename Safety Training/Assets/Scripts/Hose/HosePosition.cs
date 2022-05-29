using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HosePosition : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 startRot;
    OVRGrabbable grabable;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.parent.transform.localPosition;
        startRot = transform.parent.transform.localRotation.eulerAngles;
        grabable = gameObject.GetComponent<OVRGrabbable>();
    }

    private void FixedUpdate()
    {
        if (!grabable.isGrabbed)
        {
            transform.parent.transform.localPosition = startPos;
            transform.parent.transform.localRotation = Quaternion.Euler(startRot);
            transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
