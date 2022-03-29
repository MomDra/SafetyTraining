using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform target;
    Rigidbody rbTarget;
    Rigidbody rb;

    bool canFollow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbTarget = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canFollow)
            rb.MovePosition(rbTarget.position);
        else{
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void setFollow(bool canFollow){
        this.canFollow = canFollow;
    }
}
