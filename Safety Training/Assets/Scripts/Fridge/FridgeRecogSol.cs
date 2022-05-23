using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRecogSol : MonoBehaviour
{
    public bool correctPosPass = true;
    private string locTag;
    public bool benzenPass = true;
    public bool flammabilityPass = true;

    private void Awake() {
        GameManager.Instance.BottleManager.registFridgeRecogSolList(this);
    }


    // 떨어질 때도 처리를 해야 하는지 고민 중
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
        if (collision.gameObject.layer == LayerMask.NameToLayer("FridgeBoard"))
        {   
            bool tmp1 = correctPosPass;
            correctPosPass = false;
            
            if(tmp1 != correctPosPass){
                GameManager.Instance.BottleManager.CorrectPosPassCheck();
            }
            
        
            locTag = collision.gameObject.tag;

            //바닥에서 떨어져도 false 처리 == 들고 있을 때도
            //벤젠/산화제 
            if (transform.CompareTag("FlammabilityAcid"))
            {
                bool tmp = benzenPass;
                benzenPass = false;

                if(tmp != benzenPass){
                    GameManager.Instance.BottleManager.BenzenPassCheck();
                }
            }
                    
            if (transform.CompareTag("FlammabilityAcid") || transform.CompareTag("FlammabilityBase"))
            {
                bool tmp = flammabilityPass;
                flammabilityPass = false;

                if(tmp != flammabilityPass){
                    GameManager.Instance.BottleManager.FlammabilityPassCheck();
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
                bool tmp = correctPosPass;
                correctPosPass = true;
                
                if(tmp != correctPosPass){
                    GameManager.Instance.BottleManager.CorrectPosPassCheck();
                }
            }
            else
            {
                bool tmp1 = correctPosPass;
                correctPosPass = false;
                if(tmp1 != correctPosPass){
                    GameManager.Instance.BottleManager.CorrectPosPassCheck();
                }

                locTag = collision.gameObject.tag;
                //벤젠/산화제
                if ((locTag == "FlammabilityAcid" && transform.CompareTag("InorganicBase")) || (locTag == "InorganicBase" && transform.CompareTag("FlammabilityAcid")))
                {
                    bool tmp = benzenPass;
                    benzenPass = false;

                    if(tmp != benzenPass){
                        GameManager.Instance.BottleManager.BenzenPassCheck();
                    }
                }
                else
                {
                    bool tmp = benzenPass;
                    benzenPass = true;

                    if(tmp != benzenPass){
                        GameManager.Instance.BottleManager.BenzenPassCheck();
                    }
                }
                //인화성
                if ((locTag == "InorganicBase" || locTag == "InorganicAcid") && (transform.CompareTag("FlammabilityAcid") || transform.CompareTag("FlammabilityBase")))
                {
                    bool tmp = flammabilityPass;
                    flammabilityPass = false;

                    if(tmp != flammabilityPass){
                        GameManager.Instance.BottleManager.FlammabilityPassCheck();
                    }
                }
                else
                {
                    bool tmp = flammabilityPass;
                    flammabilityPass = true;

                    if(tmp != flammabilityPass){
                        GameManager.Instance.BottleManager.FlammabilityPassCheck();
                    }
                }
            }
        }
    }
}
