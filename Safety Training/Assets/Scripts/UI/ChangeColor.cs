using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Material red;
    [SerializeField] Material green;

    public void Red(){
        GetComponent<MeshRenderer>().material = red;
    }

    public void Green(){
        GetComponent<MeshRenderer>().material = green;
    }
}
