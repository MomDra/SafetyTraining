using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkWater : MonoBehaviour
{
    public ParticleSystem sinkWater;
    public float x;
    AudioSource audioSource;

    [SerializeField]
    AudioClip waterStart;
    [SerializeField]
    AudioClip waterIng;
    [SerializeField]
    AudioClip waterEnd;
    //public float y;
    //public float z;

    IEnumerator coroutine;


    //public InputHelpers.Button activationButton;
    public float activationThreshold = 0.1f;

    private float timer = 0f;

    bool isOpened;

    // Start is called before the first frame update
    void Start()
    {
        //sinkWater = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();

        coroutine = WaterStartCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.localEulerAngles.x;
        //y = transform.localEulerAngles.y;
        //z = transform.localEulerAngles.z;
        
        
        //Debug.Log("손잡이 각도(x,y,z): (" + x + ", " + y + ", " + z + ")");


        if (x > 1.5)
        {
            sinkWater.Play();
            StartCoroutine(coroutine);
        }
        else if (x < 2 && x > 0 || x > 21 && x <= 180)
        {
            sinkWater.Pause();
            sinkWater.Clear();

            StopCoroutine(coroutine);
            audioSource.clip = waterEnd;
            audioSource.loop = false;

            Debug.Log("끝 재생중");
        }
    }

    IEnumerator WaterStartCoroutine()
    {
        audioSource.clip = waterStart;
        audioSource.Play();

        while (true)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = waterIng;
                audioSource.loop = true;

                Debug.Log("떨어지는 중 재생중");

                break;
            }

            Debug.Log("시작 재생중!");

            yield return null;
        }
    }
}