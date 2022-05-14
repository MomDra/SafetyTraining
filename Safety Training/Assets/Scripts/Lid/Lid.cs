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

    /*
    private void LateUpdate() {
        if(!grabable.isGrabbed && locked)
        {
            lid.transform.position = transform.position;
            lid.transform.rotation = transform.rotation;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter : "+locked);
        if (locked) return;
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Lid") && !grabable.isGrabbed)
        {
            locked = true;
            other.transform.parent = transform;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit : " + locked);
        if (!locked) return;
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Lid") && grabable.isGrabbed)
        {
            locked = false;
            transform.DetachChildren();
        }
    }
}
