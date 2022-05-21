using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRecogSol : MonoBehaviour
{
    public bool wrongPosition = false;
    public string abnormalTag;
    // wrongPosition가 true일 때 tag를 반환하게 해서 잘못 놓인 것을 확인
    // wrongPosition이 true이더라도 잘못 놓인 시약병 중 하나를 제거할 때 일시적으로 false로 전환?

    //해당 스크립트를 포함한 오브젝트의 태그와 비교
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bottle"))
        {
            if (!collision.gameObject.CompareTag(transform.tag))
            {
                abnormalTag = collision.gameObject.tag;
                wrongPosition = false;
                Debug.Log("+++OnCollisionExit -- abnormalTag : " + abnormalTag + ", wrongPosition : " + wrongPosition);
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bottle"))
        {
            if (!collision.gameObject.CompareTag(transform.tag))
            {
                abnormalTag = collision.gameObject.tag;
                wrongPosition = true;
                Debug.Log("+++OnCollisionEnter -- abnormalTag : " + abnormalTag + ", wrongPosition : " + wrongPosition);
            }
        }
    }
}
