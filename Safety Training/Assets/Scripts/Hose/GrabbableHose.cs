using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableHose : OVRGrabbable
{
    [SerializeField] Transform staticHandle;
    [SerializeField] GameObject outLineObject;

    [SerializeField] Transform originPos;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        staticHandle.GetComponent<FollowHose>().setFollow(true);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        transform.position = originPos.transform.position;
        transform.rotation = originPos.transform.rotation;

        staticHandle.GetComponent<FollowHose>().setFollow(false);

        Rigidbody rbHandler = staticHandle.GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;

        if (outLineObject.GetComponent<OutlineOnly>() != null)
        {
            Destroy(outLineObject.GetComponent<OutlineOnly>());
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(originPos.position, GetComponent<Rigidbody>().position) > 1f)
        {
            if (grabbedBy != null) grabbedBy.ForceRelease(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("HandLeft") || other.gameObject.layer == LayerMask.NameToLayer("HandRight"))
        {
            if (outLineObject.GetComponent<OutlineOnly>() == null)
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
