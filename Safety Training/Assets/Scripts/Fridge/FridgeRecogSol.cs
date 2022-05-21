using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRecogSol : MonoBehaviour
{
    public bool wrongPosition = false;
    public string abnormalTag;
    // wrongPosition�� true�� �� tag�� ��ȯ�ϰ� �ؼ� �߸� ���� ���� Ȯ��
    // wrongPosition�� true�̴��� �߸� ���� �þິ �� �ϳ��� ������ �� �Ͻ������� false�� ��ȯ?

    //�ش� ��ũ��Ʈ�� ������ ������Ʈ�� �±׿� ��
    
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
