using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // ������
    private RaycastHit Collided_object; // �浹�� ��ü
    private GameObject currentObject;   // ���� �ֱٿ� �浹�� ��ü�� �����ϱ� ���� ��ü

    public float raycastDistance = 90f; // ���� ���� �Ÿ�

    // Start is called before the first frame update
    void Start()
    {

        layser = this.gameObject.AddComponent<LineRenderer>();

        Material material = new Material(Shader.Find("Standard")); //���� ����
        material.color = new Color(0, 0, 0, 0.5f);
        layser.material = material;
        // �������� �������� 2�� �ʿ�
        layser.positionCount = 2;

        //�������� ����
        layser.startWidth = 0.05f;
        layser.endWidth = 0.05f;
    }

    void Update()
    {
        layser.SetPosition(0, transform.position); // ù��° ������ ĳ������ġ

        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f); //������ ��


        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance))//��ü���� �浹 ��
        {
            layser.SetPosition(1, Collided_object.point);

            if (Collided_object.collider.gameObject.CompareTag("Button")) // �浹�� ��ü�� �±� Button�� ���(UI ��ư ��ü�� �±׸� Button���� ����)
            {
                if (OVRInput.GetDown(OVRInput.Button.One)) //��ŧ���� ������ ��Ʈ�ѷ� A��ư Ŭ����
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

        else //�������� ������ ��ü�� ���� ���
        {
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));//������ �ʱ� ���� ���̸�ŭ ��� ����

            // �ֱ� ������ ������Ʈ�� Button�� ���
            // ��ư�� ���� �����ִ� �����̹Ƿ� �̰��� Ǯ���ش�.
            if (currentObject != null)
            {
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
            }

        }

    }

    private void LateUpdate()
    {

        if (OVRInput.GetDown(OVRInput.Button.One)) //��ŧ���� ��ư A�� ���� ���
        {
            layser.material.color = new Color(255, 255, 255, 0.5f);//������ ���� ����
        }

        else if (OVRInput.GetUp(OVRInput.Button.One))//��ŧ���� ��ư A�� �� ���
        {
            layser.material.color = new Color(0, 0, 0, 0.5f);//������ ���� ����
        }
    }
}

