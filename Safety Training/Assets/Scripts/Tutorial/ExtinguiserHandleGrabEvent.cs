using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguiserHandleGrabEvent : MonoBehaviour
{
    TutorialManager manager;
    PutCorrectionGrabable grabable;

    Transform hoseHandle;

    private void Awake() {
        manager = FindObjectOfType<TutorialManager>();

        grabable = GetComponent<PutCorrectionGrabable>();

        grabable.grabBeginEvent.AddListener(GrabBegin);

        hoseHandle = transform.Find("HozeHandle");
    }

    void GrabBegin(){
        if(manager.Index == 10){
            manager.PlayAudioAndText(10);
            
            
            // 호스에 아웃라인
            if(hoseHandle.GetComponent<OutlineOnly>() == null){
                OutlineOnly outline =  hoseHandle.gameObject.AddComponent<OutlineOnly>();
                outline.OutlineColor = Color.magenta;
                outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
            }
            
            if(GetComponent<OutlineOnly>() != null){
                Destroy(GetComponent<OutlineOnly>());
            }
        }
    }
}
