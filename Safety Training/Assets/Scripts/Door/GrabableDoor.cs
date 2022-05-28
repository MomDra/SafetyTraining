using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableDoor : OVRGrabbable
{
    [SerializeField] Transform staticHandle;
    [SerializeField] GameObject outLineObject;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        staticHandle.GetComponent<FollowObject>().setFollow(true);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        staticHandle.GetComponent<FollowObject>().setFollow(false);

        transform.position = staticHandle.transform.position;
        transform.rotation = staticHandle.transform.rotation;

        Rigidbody rbHandler = staticHandle.GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;

        if (outLineObject.GetComponent<OutlineOnly>() != null)
        {
            Destroy(outLineObject.GetComponent<OutlineOnly>());
        }
    }

    private void FixedUpdate() {
        if(Vector2.Distance(staticHandle.GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().position) > 0.5f){
            grabbedBy.ForceRelease(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("HandLeft") || other.gameObject.layer == LayerMask.NameToLayer("HandRight"))
        {
            if(outLineObject.GetComponent<OutlineOnly>() == null)
            {
                OutlineOnly outline = outLineObject.AddComponent<OutlineOnly>();
                outline.OutlineColor = Color.green;
                outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("HandLeft") || other.gameObject.layer == LayerMask.NameToLayer("HandRight"))
        {
            if (outLineObject.GetComponent<OutlineOnly>() != null)
            {
                Destroy(outLineObject.GetComponent<OutlineOnly>());
            }
        }
    }
}
