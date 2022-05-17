using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSolRecog : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("시약종류"))
        {

        }
    }
}
