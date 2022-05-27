using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    bool isWearMask;


    private void OnTriggerEnter(Collider other)
    {
        if(!isWearMask && other.CompareTag("Mask"))
        {
            Debug.Log("¹æµ¶¸é ¾¸");

            isWearMask = true;
            Destroy(other.gameObject);
        }
    }
}
