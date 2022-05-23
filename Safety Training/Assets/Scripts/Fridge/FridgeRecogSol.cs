using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRecogSol : MonoBehaviour
{
    public bool correctPosPass = true;
    private string locTag;
    public bool benzenPass = true;
    public bool flammabilityPass = true;


    // ������ ���� ó���� �ؾ� �ϴ��� ��� ��
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

                //�ٴڿ��� �������� false ó�� == ��� ���� ����
                //����/��ȭ�� 
                if (transform.CompareTag("FlammabilityAcid"))
                {
                    benzenPass = false;
                }
                //��ȭ��
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
                //����/��ȭ��
                if ((locTag == "FlammabilityAcid" && transform.CompareTag("InorganicBase")) || (locTag == "InorganicBase" && transform.CompareTag("FlammabilityAcid")))
                {
                    benzenPass = false;
                }
                else
                {
                    benzenPass = true;
                }
                //��ȭ��
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
