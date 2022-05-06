using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    bool trigger;
    [SerializeField] Transform followPoint;
    PutCorrectionGrabable grabable;

    // Start is called before the first frame update
    void Start()
    {
        grabable = GetComponent<PutCorrectionGrabable>();

        grabable.grabBeginEvent.AddListener(setTriggerTrue);
    }

    private void LateUpdate() {
        if(!grabable.isGrabbed && !trigger){
            transform.position = followPoint.transform.position;
            transform.rotation = followPoint.transform.rotation;
        }
    }

    private void setTriggerTrue(){
        trigger = true;
    }
}
