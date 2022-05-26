using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : MonoBehaviour
{
    public bool gasLocked = true;
    public float x;

    bool isCoroutineStarted;

    [SerializeField]
    float time;

    [SerializeField]
    bool isEmergency = false;

    IEnumerator coroutine;


    private void Awake()
    {
        coroutine = Timer();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.localEulerAngles.x;

        

        if (x > 20f && x <= 90f)// ���� ���� ����
        {
            gasLocked = false;

            if (isCoroutineStarted == false)
            {
                isCoroutineStarted = true;
                StartCoroutine(coroutine);
            }
                
        }
        else if (x > 0f && x <= 20f) // ���� ���� ����
        {
            gasLocked = true;

            if (isCoroutineStarted == true && !isEmergency)
            {
                isCoroutineStarted = false;
                StopCoroutine(coroutine);
            }
            else
            {

            }
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("�溸 ����");
        GameManager.Instance.EmergencyManager.EmergencyStart(EmergencyType.Leak);
        isEmergency = true;
    }
}
