using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberOutline : OVRGrabber
{
    protected override void OnTriggerEnter(Collider other)
    {
        OVRGrabbable grabbable = other.GetComponent<OVRGrabbable>();
            //?? other.GetComponentInParent<OVRGrabbable>();
        if (grabbable == null) return;
        base.OnTriggerEnter(other);

        OVRInput.SetControllerVibration(1, 0.2f, m_controller);
        Invoke("EndVibration", 0.2f);

        if (grabbable.GetComponent<OutlineOnly>() == null)
        {
            OutlineOnly outline = grabbable.gameObject.AddComponent<OutlineOnly>();
            outline.OutlineColor = Color.green;
            outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        OVRGrabbable grabbable = other.GetComponent<OVRGrabbable>();
        //?? other.GetComponentInParent<OVRGrabbable>();
        if (grabbable == null) return;
        base.OnTriggerExit(other);


        if (grabbable.GetComponent<OutlineOnly>() != null)
        {
            Destroy(grabbable.GetComponent<OutlineOnly>());
        }
    }

    void EndVibration()
    {
        OVRInput.SetControllerVibration(0, 0, m_controller);
    }
}
