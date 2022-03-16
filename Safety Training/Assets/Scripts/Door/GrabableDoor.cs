using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableDoor : OVRGrabbable
{
    [SerializeField] Transform staticHandle;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        transform.position = staticHandle.transform.position;
        transform.rotation = staticHandle.transform.rotation;

        Rigidbody rbHandler = staticHandle.GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate() {
        if(Vector2.Distance(staticHandle.GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().position) > 0.5f){
            grabbedBy.ForceRelease(this);
        }
    }
}
