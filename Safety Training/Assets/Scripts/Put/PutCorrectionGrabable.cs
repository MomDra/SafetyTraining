using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PutCorrectionGrabable : OVRGrabbable
{
    [SerializeField] GameObject previewPrefab;
    bool isInCollider;
    Vector3 pos;
    Quaternion rotation;

    // 그랩이 시작되면 호출할 이벤트...
    public UnityEvent grabBeginEvent;
    public UnityEvent grabEndEvent;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        if (!isInCollider)
        { // 정상적인 GrabEnd
            base.GrabEnd(linearVelocity, angularVelocity);
        }
        else
        { // 놓기 보정 GrabEnd
            base.GrabEnd(Vector3.zero, Vector3.zero);
            transform.position = pos;
            transform.rotation = rotation;
        }

        grabEndEvent.Invoke();
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        if(GetComponent<OutlineOnly>() != null)
        {
            Destroy(GetComponent<OutlineOnly>());
        }

        grabBeginEvent.Invoke();
    }





    // 보정 콜라이더에 들어가면 거기서 호출해줌
    public void setInCollider(bool isInCollider, Vector3 pos, Quaternion rotation)
    {
        this.isInCollider = isInCollider;
        this.pos = pos;
        this.rotation = rotation;
    }

    // 보정 콜라이더 쪽에서 호출할거임
    public GameObject getPreview()
    {
        return previewPrefab;
    }
}
