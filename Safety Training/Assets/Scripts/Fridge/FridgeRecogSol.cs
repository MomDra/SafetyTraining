using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRecogSol : MonoBehaviour
{
    public bool correctPosPass = true;
    public bool _CorrectPosPass {get => allPass? true : correctPosPass;}
    private string locTag;
    public bool benzenPass = true;
    public bool flammabilityPass = true;
    public bool allPass = false;

    private void Awake() {
        GameManager.Instance.BottleManager.registFridgeRecogSolList(this);
    }


    // ������ ���� ó���� �ؾ� �ϴ��� ���� ��
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
        if (collision.gameObject.layer == LayerMask.NameToLayer("FridgeBoard"))
        {   
            bool tmp1 = correctPosPass;
            correctPosPass = false;
            
            if(tmp1 != correctPosPass){
                GameManager.Instance.BottleManager.CorrectPosPassCheck();
                Debug.Log("CorrectPosPassCheck  : " + correctPosPass);
            }
            
        
            locTag = collision.gameObject.tag;

            //�ٴڿ��� �������� false ó�� == ��� ���� ����
            //����/��ȭ�� 
            if (transform.CompareTag("FlammabilityAcid"))
            {
                bool tmp = benzenPass;
                benzenPass = false;

                if(tmp != benzenPass){
                    GameManager.Instance.BottleManager.BenzenPassCheck();
                    Debug.Log("BenzenPassCheck  : " + benzenPass);
                }
            }
                    
            if (transform.CompareTag("FlammabilityAcid") || transform.CompareTag("FlammabilityBase"))
            {
                bool tmp = flammabilityPass;
                flammabilityPass = false;

                if(tmp != flammabilityPass){
                    GameManager.Instance.BottleManager.FlammabilityPassCheck();
                    Debug.Log("FlammabilityPassCheck  : " + flammabilityPass);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("FridgeBoard"))
        {
            if (collision.gameObject.CompareTag(transform.tag))
            {
                bool tmp = correctPosPass;
                correctPosPass = true;
                
                if(tmp != correctPosPass){
                    GameManager.Instance.BottleManager.PositionAllCheck();
                }
            }
            else
            {
                bool tmp1 = correctPosPass;
                correctPosPass = false;
                if(tmp1 != correctPosPass){
                    GameManager.Instance.BottleManager.CorrectPosPassCheck();
                    Debug.Log("CorrectPosPassCheck  : " + correctPosPass);
                }
                locTag = collision.gameObject.tag;
                //����/��ȭ��
                if ((locTag == "FlammabilityAcid" && transform.CompareTag("InorganicBase")) || (locTag == "InorganicBase" && transform.CompareTag("FlammabilityAcid")))
                {
                    bool tmp = benzenPass;
                    benzenPass = false;

                    if(tmp != benzenPass){
                        GameManager.Instance.BottleManager.BenzenPassCheck();
                        Debug.Log("BenzenPassCheck  : " + benzenPass);
                    }
                }
                else
                {
                    bool tmp = benzenPass;
                    benzenPass = true;

                    if(tmp != benzenPass){
                        GameManager.Instance.BottleManager.BenzenPassCheck();
                        Debug.Log("BenzenPassCheck  : " + benzenPass);
                    }
                }
                //��ȭ��
                if ((locTag == "InorganicBase" || locTag == "InorganicAcid") && (transform.CompareTag("FlammabilityAcid") || transform.CompareTag("FlammabilityBase")))
                {
                    bool tmp = flammabilityPass;
                    flammabilityPass = false;

                    if(tmp != flammabilityPass){
                        GameManager.Instance.BottleManager.FlammabilityPassCheck();
                        Debug.Log("FlammabilityPassCheck  : " + flammabilityPass);
                    }
                }
                else
                {
                    bool tmp = flammabilityPass;
                    flammabilityPass = true;

                    if(tmp != flammabilityPass){
                        GameManager.Instance.BottleManager.FlammabilityPassCheck();
                        Debug.Log("FlammabilityPassCheck  : " + flammabilityPass);
                    }
                }
            }
        }
    }
}
