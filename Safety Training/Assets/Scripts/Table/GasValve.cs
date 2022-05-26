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

        

        if (x > 20f && x <= 90f)// 가스 벨브 열림
        {
            gasLocked = false;

            if (isCoroutineStarted == false)
            {
                isCoroutineStarted = true;
                StartCoroutine(coroutine);
            }
                
        }
        else if (x > 0f && x <= 20f) // 가스 벨브 닫힘
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
        Debug.Log("경보 시작");
        GameManager.Instance.EmergencyManager.EmergencyStart(EmergencyType.Leak);
        isEmergency = true;
    }
}
