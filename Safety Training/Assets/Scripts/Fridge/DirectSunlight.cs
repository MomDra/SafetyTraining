using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectSunlight : MonoBehaviour
{
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("FridgeBoard"))
        {
            GameManager.Instance.BottleManager.DirectSunlightPassCheck = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("FridgeBoard"))
        {
            GameManager.Instance.BottleManager.DirectSunlightPassCheck = true;
        }
    }
}
