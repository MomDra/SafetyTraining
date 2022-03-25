using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCorrectionGrabable : OVRGrabbable
{
    bool isInCollider;
    Vector3 pos;
    Quaternion rotation;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        if(!isInCollider){ // 정상적인 GrabEnd
            base.GrabEnd(linearVelocity, angularVelocity);
        }
        else{ // 놓기 보정 GrabEnd
            base.GrabEnd(Vector3.zero, Vector3.zero);
            transform.position = pos;
            transform.rotation = rotation;
        }
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
    }

    public void setInCollider(bool isInCollider, Vector3 pos, Quaternion rotation){
        this.isInCollider = isInCollider;
        this.pos = pos;
        this.rotation = rotation;
    }
}
