using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCorrection : MonoBehaviour
{
    GameObject previewGameObject;
    private void OnTriggerEnter(Collider other) {
        if(other.transform.gameObject.layer == LayerMask.NameToLayer("Grabable")){

            // 잡고 있는 물건의 Mesh 정보
            MeshFilter meshFilter = other.GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();

            // 미리보기 오브젝트의 설정
            previewGameObject = GameManager.Instance.ResourceManager.Instantiate("PutPreview/PreviewCylinder");
            previewGameObject.transform.position = transform.position;

            Debug.Log("놓기 보정 오브젝트 생성!");
        }
    }

    private void OnTriggerExit(Collider other) {
        Destroy(previewGameObject);
        Debug.Log("놓기 보정 오브젝트 삭제!");
    }
}
