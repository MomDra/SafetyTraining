using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberOutline : OVRGrabber
{
    protected override void OnTriggerEnter(Collider other)
    {
        OVRGrabbable grabbable = other.GetComponent<OVRGrabbable>() ?? other.GetComponentInParent<OVRGrabbable>();
        if (grabbable == null) return;
        base.OnTriggerEnter(other);

        OVRInput.SetControllerVibration(1, 0.2f, m_controller);
        Invoke("EndVibration", 0.2f);

        if (grabbable.GetComponent<Outline>() == null)
        {
            Outline outline = grabbable.gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.green;
            outline.OutlineMode = Outline.Mode.OutlineAll;
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        OVRGrabbable grabbable = other.GetComponent<OVRGrabbable>() ?? other.GetComponentInParent<OVRGrabbable>();
        if (grabbable == null) return;
        base.OnTriggerExit(other);


        if (grabbable.GetComponent<Outline>() != null)
        {
            Destroy(grabbable.GetComponent<Outline>());
        }
    }

    void EndVibration()
    {
        OVRInput.SetControllerVibration(0, 0, m_controller);
    }
}
