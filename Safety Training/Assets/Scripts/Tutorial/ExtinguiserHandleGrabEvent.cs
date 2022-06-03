using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguiserHandleGrabEvent : MonoBehaviour
{
    TutorialManager manager;
    PutCorrectionGrabable grabable;

    private void Awake() {
        grabable = GetComponent<PutCorrectionGrabable>();

        grabable.grabBeginEvent.AddListener(GrabBegin);
    }

    void GrabBegin(){
        if(manager.Index == 10){
            manager.PlayAudioAndText(10);
            
            /*
            // 호스에 아웃라인
            if(lid.GetComponent<OutlineOnly>() == null){
                OutlineOnly outline =  lid.gameObject.AddComponent<OutlineOnly>();
                outline.OutlineColor = Color.magenta;
                outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
            }
            */
        }
    }
}
