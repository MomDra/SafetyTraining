using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRecogSol : MonoBehaviour
{
    bool IntegrityCheck = true;
    public int abnormalObjCount = 0;

    //�ش� ��ũ��Ʈ�� ������ ������Ʈ�� �±׿� ��
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag(transform.tag))
        {
            abnormalObjCount -= 1;
            if (abnormalObjCount > 0) IntegrityCheck = false;
            Debug.Log("--- OnCollisionExit : " + collision.gameObject.tag + ", Current : " + transform.tag);
            Debug.Log("abnormalObjCount : " + abnormalObjCount + ", IntegrityCheck : " + IntegrityCheck);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(transform.tag))
        {
            abnormalObjCount += 1;
            if (abnormalObjCount == 0) IntegrityCheck = true;
            Debug.Log("+++ OnCollisionEnter : " + collision.gameObject.tag + ", Current : " + transform.tag);
            Debug.Log("abnormalObjCount : " + abnormalObjCount + ", IntegrityCheck : " + IntegrityCheck);
        }
    }
}
