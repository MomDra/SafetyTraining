using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseGrabEvent : MonoBehaviour
{
    TutorialManager manager;
    GrabbableHose grabbable;

    [SerializeField]
    GameObject fire;

    private void Awake() {
        manager = FindObjectOfType<TutorialManager>();

        grabbable = GetComponent<GrabbableHose>();

        grabbable.grabBeginEvent.AddListener(GrabBegin);
    }

    void GrabBegin(){
        if(manager.Index == 11){
            manager.PlayAudioAndText(11);

            fire.SetActive(true);

            if(GetComponent<OutlineOnly>() != null){
                Destroy(GetComponent<OutlineOnly>());
            }
        }
    }
}
