using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // 레이저
    private RaycastHit Collided_object; // 충돌된 객체
    private GameObject currentObject;   // 가장 최근에 충돌한 객체를 저장하기 위한 객체

    public float raycastDistance = 90f; // 레이 감지 거리

    // Start is called before the first frame update
    void Start()
    {

        layser = this.gameObject.AddComponent<LineRenderer>();

        Material material = new Material(Shader.Find("Standard")); //라인 색상
        material.color = new Color(0, 0, 0, 0.5f);
        layser.material = material;
        // 레이저의 꼭지점은 2개 필요
        layser.positionCount = 2;

        //레이저의 굵기
        layser.startWidth = 0.05f;
        layser.endWidth = 0.05f;
    }

    void Update()
    {
        layser.SetPosition(0, transform.position); // 첫번째 시작점 캐릭터위치

        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f); //레이저 선


        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance))//물체와의 충돌 시
        {
            layser.SetPosition(1, Collided_object.point);

            if (Collided_object.collider.gameObject.CompareTag("Button")) // 충돌된 객체의 태그 Button인 경우(UI 버튼 객체에 태그를 Button으로 설정)
            {
                if (OVRInput.GetDown(OVRInput.Button.One)) //오큘러스 오른손 컨트롤러 A버튼 클릭시
                {
                    Collided_object.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    Debug.Log("hi" +Collided_object.transform.name );
                }
                else
                {
                    Collided_object.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                    currentObject = Collided_object.collider.gameObject;
                }
            }
        }

        else //레이저에 감지된 객체가 없을 경우
        {
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));//레이저 초기 설정 길이만큼 길게 만듦

            // 최근 감지된 오브젝트가 Button인 경우
            // 버튼은 현재 눌려있는 상태이므로 이것을 풀어준다.
            if (currentObject != null)
            {
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
            }

        }

    }

    private void LateUpdate()
    {

        if (OVRInput.GetDown(OVRInput.Button.One)) //오큘러스 버튼 A를 누를 경우
        {
            layser.material.color = new Color(255, 255, 255, 0.5f);//레이저 색상 변경
        }

        else if (OVRInput.GetUp(OVRInput.Button.One))//오큘러스 버튼 A를 뗄 경우
        {
            layser.material.color = new Color(0, 0, 0, 0.5f);//레이저 색상 변경
        }
    }
}

