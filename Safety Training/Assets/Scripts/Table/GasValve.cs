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

    AudioSource audioSource;

    bool isTrigger;

    IEnumerator coroutine;


    private void Awake()
    {
        coroutine = Timer();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        z = transform.localEulerAngles.z;
        

        if (z > 120f && z <= 180f)// 가스 벨브 열림
        {
            //Debug.Log("Valve opened : "+z);
            gasLocked = false;
            if (!audioSource.isPlaying) audioSource.Play();

            if (isCoroutineStarted == false)
            {
                isCoroutineStarted = true;
                StartCoroutine(coroutine);
            }

            if (!isTrigger)
            {
                isTrigger = true;
                GameManager.Instance.EmergencyManager.IsClosedValve = false;
            }
                
        }
        else if (z >= 90f && z <= 120f) // 가스 벨브 닫힘
        {
            //Debug.Log("Valve closed : " + z);
            gasLocked = true;
            if (audioSource.isPlaying) audioSource.Stop();

            if (isCoroutineStarted == true && !isEmergency)
            {
                isCoroutineStarted = false;
                StopCoroutine(coroutine);
            }

            if (isTrigger)
            {
                isTrigger = false;
                GameManager.Instance.EmergencyManager.IsClosedValve = true;
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
