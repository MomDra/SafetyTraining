using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    bool locked = true;
    public GameObject lid;
    PutCorrectionGrabable grabable;

    // Start is called before the first frame update
    void Start()
    {
        grabable = lid.GetComponent<PutCorrectionGrabable>();

        //grabable.grabBeginEvent.AddListener(setTriggerTrue);
    }

    private void LateUpdate() {
        if(!grabable.isGrabbed && locked)
        {
            lid.transform.position = transform.position;
            lid.transform.rotation = transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (locked) return;
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Lid"))
            locked = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(!locked) return;
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Lid"))
            locked = false;
    }

}
