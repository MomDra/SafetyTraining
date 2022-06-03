using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleGrabEvent : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    Lid lid;
    TutorialManager manager;

    private void Awake() {
        manager = FindObjectOfType<TutorialManager>();
        lid = GetComponentInChildren<Lid>();

        grabable = GetComponent<PutCorrectionGrabable>();
        grabable.grabBeginEvent.AddListener(GrabBegin);
    }

    void GrabBegin(){
        manager.PlayAudioAndText(6);
        
        if(lid.GetComponent<OutlineOnly>() == null){
            lid.gameObject.AddComponent<OutlineOnly>();
        }
    }
}
