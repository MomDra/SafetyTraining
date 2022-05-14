using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    public bool locked = true;
    public GameObject lid;
    PutCorrectionGrabable grabable;

    //float distance = 0f;
    //float time = 0f;
    //bool trigger = true;

    // Start is called before the first frame update
    void Start()
    {
        //grabable.grabBeginEvent.AddListener(setTriggerTrue);
    }

    void FixedUpdate()
    {
        Debug.Log("Lid Locked : "+locked);
        if(lid && lid.GetComponent<PutCorrectionGrabable>().isGrabbed)
        {
            {
                lid.transform.GetComponent<Rigidbody>().isKinematic = false;
                //lid.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                lid.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                lid.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("OnTriggerExit : " + other);
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Lid"))
        {
            grabable = other.GetComponent<PutCorrectionGrabable>();

            if (!other.transform.parent && !grabable.isGrabbed)
            {
                //Debug.Log("!!!!!other.transform.parent : " + other.transform.parent);
                return;
            }
            locked = false;
            //other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.DetachChildren();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (locked) return;
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Lid"))
        {
            grabable = other.GetComponent<PutCorrectionGrabable>();

            if (other.transform.parent)
            {
                //Debug.Log("other.transform.parent : " + other.transform.parent);
                return;
            }
            locked = true;
            other.transform.parent = transform;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    
}
