using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCorrection : MonoBehaviour
{
    GameObject previewGameObject;
    PutCorrectionGrabable grabbed;

    bool objectInColider;
    private void OnTriggerEnter(Collider other) {
        if(objectInColider) return;

        if(other.transform.gameObject.layer == LayerMask.NameToLayer("Grabable")){
            objectInColider = true;

            // 미리보기 오브젝트의 설정
            previewGameObject = Instantiate(other.GetComponent<PutCorrectionGrabable>().getPreview(), transform.position, Quaternion.identity);
            
            // previewGameObject.transform.position = transform.position;

            grabbed = other.GetComponent<PutCorrectionGrabable>();
            grabbed.setInCollider(true, transform.position, previewGameObject.transform.rotation);

            Debug.Log("놓기 보정 오브젝트 생성!");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(!objectInColider) return;

        objectInColider = false;
        grabbed.setInCollider(false, Vector3.zero, Quaternion.identity);
        Destroy(previewGameObject);
        Debug.Log("놓기 보정 오브젝트 삭제!");
    }
}
