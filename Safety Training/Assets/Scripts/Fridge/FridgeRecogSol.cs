using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRecogSol : MonoBehaviour
{
    public bool correctPosPass = true;
    private string locTag;
    public bool benzenPass = true;
    public bool flammabilityPass = true;


    // 떨어질 때도 처리를 해야 하는지 고민 중
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
        if (collision.gameObject.layer == LayerMask.NameToLayer("FridgeBoard"))
        {
            if (collision.gameObject.CompareTag(transform.tag))
            {
                correctPosPass = false;
            }
            else
            {
                locTag = collision.gameObject.tag;

                //바닥에서 떨어져도 false 처리 == 들고 있을 때도
                //벤젠/산화제 
                if (transform.CompareTag("FlammabilityAcid"))
                {
                    benzenPass = false;
                }
                //인화성
                if (transform.CompareTag("FlammabilityAcid") || transform.CompareTag("FlammabilityBase"))
                {
                    flammabilityPass = false;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("FridgeBoard"))
        {
            Debug.Log("OnCollisionEnter  : " + transform.name);
            if (collision.gameObject.CompareTag(transform.tag))
            {
                correctPosPass = true;
            }
            else
            {
                correctPosPass = false;
                locTag = collision.gameObject.tag;
                //벤젠/산화제
                if ((locTag == "FlammabilityAcid" && transform.CompareTag("InorganicBase")) || (locTag == "InorganicBase" && transform.CompareTag("FlammabilityAcid")))
                {
                    benzenPass = false;
                }
                else
                {
                    benzenPass = true;
                }
                //인화성
                if ((locTag == "InorganicBase" || locTag == "InorganicAcid") && (transform.CompareTag("FlammabilityAcid") || transform.CompareTag("FlammabilityBase")))
                {
                    flammabilityPass = false;
                }
                else
                {
                    flammabilityPass = true;
                }
            }
        }
    }
}
