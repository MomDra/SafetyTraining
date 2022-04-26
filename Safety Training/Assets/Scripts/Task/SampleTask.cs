using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTask : Task
{
    OVRGrabbable grabbable;

    private void Start() {
        grabbable = GetComponent<OVRGrabbable>();
    }

    
    private void OnTriggerStay(Collider other) {
        if(!isSolved){
            if(other.gameObject.name.Contains("Task_Put")){
                if(!grabbable.isGrabbed){
                    Solve();
                }
            }
        }
    }
}
