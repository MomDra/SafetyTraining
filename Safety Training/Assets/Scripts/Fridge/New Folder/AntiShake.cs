using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiShake : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
