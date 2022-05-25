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

        /*
        if (GetComponent<Outline>() != null && !isGrabbed)
        {
            Destroy(GetComponent<Outline>());
        }*/

        grabEndEvent.Invoke();
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        if(GetComponent<Outline>() != null)
        {
            Destroy(GetComponent<Outline>());
        }

        grabBeginEvent.Invoke();
        // if (GetComponent<Outline>() == null)
        // {
        //     gameObject.AddComponent<Outline>();
        //     GetComponent<Outline>().OutlineColor = Color.green;
        //     GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
        // }
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


    /*
    private void OnTriggerEnter(Collider other) { // 진동과 아웃라인 코드를 잡는 쪽에서 구현해야 되나?..
        if(other.gameObject.layer == LayerMask.NameToLayer("HandLeft")){
            OVRInput.SetControllerVibration(1, 0.2f, OVRInput.Controller.LTouch);
            Invoke("EndVibrationLeft", 0.2f);

            if (GetComponent<Outline>() == null)
            {
                gameObject.AddComponent<Outline>();
                GetComponent<Outline>().OutlineColor = Color.green;
                GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
            }

            Debug.Log(other.name);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("HandRight")){
            OVRInput.SetControllerVibration(1, 0.2f, OVRInput.Controller.RTouch);
            Invoke("EndVibrationRight", 0.2f);

            if (GetComponent<Outline>() == null)
            {
                gameObject.AddComponent<Outline>();
                GetComponent<Outline>().OutlineColor = Color.green;
                GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
            }
            Debug.Log(other.name);
        }

    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("HandLeft")){
            if (GetComponent<Outline>() != null)
            {
                Destroy(GetComponent<Outline>());
            }
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("HandRight") ){
            if (GetComponent<Outline>() != null)
            {
                Destroy(GetComponent<Outline>());
            }
        }
    }

    public void EndVibrationLeft()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }

    public void EndVibrationRight()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }*/
}
