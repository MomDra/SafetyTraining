using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    PutCorrectionGrabable grabable;
    bool lockChange = false;
    public bool locked = true;

    private void Start()
    {
        grabable = gameObject.GetComponent<PutCorrectionGrabable>();
    }
    private void Update()
    {
        //Debug.Log("lockChange: " + lockChange);
        if (grabable.isGrabbed)
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            locked = false;
        }
        else
        {
            //Debug.Log("    ---fixLoc");
            if (lockChange)
            {
                FixLid(transform.parent);
                locked = true;

            }
        }
    }

    private void FixLid(Transform _transform)
    {
        //Debug.Log("FixLid");
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LidCorrection" && other.transform == transform.parent.transform)
        {
            //Debug.Log("Exit");
            //if (other.transform.childCount > 0) return;
            lockChange = false;
            locked = false;
            //other.transform.DetachChildren();

            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (locked) return;
        if (other.tag == "LidCorrection" && other.transform == transform.parent.transform)
        {
            //Debug.Log("Enter");
            //if (transform.parent && !grabable.isGrabbed) return;
            //transform.parent = other.transform;
            lockChange = true;
        }
    }



    /*
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
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }*/
}
