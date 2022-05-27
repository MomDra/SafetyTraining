using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : MonoBehaviour
{
    public bool gasLocked = true;
    public float z;

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
        z = transform.localEulerAngles.z;
        

        if (z > 120f && z <= 180f)// ���� ���� ����
        {
            //Debug.Log("Valve opened : "+z);
            gasLocked = false;

            if (isCoroutineStarted == false)
            {
                isCoroutineStarted = true;
                StartCoroutine(coroutine);
                GameManager.Instance.EmergencyManager.IsClosedValve = false;
            }
                
        }
        else if (z >= 90f && z <= 120f) // ���� ���� ����
        {
            //Debug.Log("Valve closed : " + z);
            gasLocked = true;

            if (isCoroutineStarted == true && !isEmergency)
            {
                isCoroutineStarted = false;
                StopCoroutine(coroutine);
            }
            else
            {
                GameManager.Instance.EmergencyManager.IsClosedValve = true;
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
