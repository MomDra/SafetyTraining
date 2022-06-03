using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidGrabEvent : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    TutorialManager manager;
    [SerializeField]
    GameObject wasteLid;

    private void Awake() {
        manager = FindObjectOfType<TutorialManager>();

        grabable = GetComponent<PutCorrectionGrabable>();
        grabable.grabBeginEvent.AddListener(GrabBegin);
    }

    void GrabBegin(){
        manager.PlayAudioAndText(7);
        
        if(wasteLid.GetComponent<OutlineOnly>() == null){
            OutlineOnly outline =  wasteLid.gameObject.AddComponent<OutlineOnly>();
            outline.OutlineColor = Color.magenta;
            outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
        }
    }
}
