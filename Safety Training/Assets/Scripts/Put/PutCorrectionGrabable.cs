using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCorrectionGrabable : OVRGrabbable
{
    [SerializeField] GameObject previewPrefab;
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

        // if (GetComponent<Outline>() != null && !isGrabbed)
        // {
        //     Destroy(GetComponent<Outline>());
        // }
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        
        // if (GetComponent<Outline>() == null)
        // {
        //     gameObject.AddComponent<Outline>();
        //     GetComponent<Outline>().OutlineColor = Color.green;
        //     GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
        // }
    }

    // 보정 콜라이더에 들어가면 거기서 호출해줌
    public void setInCollider(bool isInCollider, Vector3 pos, Quaternion rotation){
        this.isInCollider = isInCollider;
        this.pos = pos;
        this.rotation = rotation;
    }

    // 보정 콜라이더 쪽에서 호출할거임
    public GameObject getPreview(){
        return previewPrefab;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("HandLeft")){
            OVRInput.SetControllerVibration(1, 0.2f, OVRInput.Controller.LTouch);
            Invoke("EndVibrationLeft", 0.2f);

            if (GetComponent<Outline>() == null)
            {
                gameObject.AddComponent<Outline>();
                GetComponent<Outline>().OutlineColor = Color.green;
                GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
            }
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
    }
}
