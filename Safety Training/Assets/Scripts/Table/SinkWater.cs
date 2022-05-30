using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkWater : MonoBehaviour
{
    public ParticleSystem sinkWater;
    public float x;
    AudioSource audioSource;


    [SerializeField]
    AudioClip waterIng;

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

        //coroutine = WaterStartCoroutine();
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
            if (!isOpened)
            {
                isOpened = true;
                sinkWater.Play();


                audioSource.Play();
            }
        }
        else if (x < 2 && x > 0 || x > 21 && x <= 180)
        {
            if (isOpened)
            {
                isOpened = false;

                sinkWater.Pause();
                sinkWater.Clear();

                audioSource.Stop();

                Debug.Log("끝 재생중");
            }
        }
    }

    /*
    IEnumerator WaterStartCoroutine()
    {
        while (true)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = waterIng;
                audioSource.loop = true;
                audioSource.Play();

                Debug.Log("떨어지는 중 재생중");

                break;
            }

            Debug.Log("시작 재생중!");

            yield return null;
        }
    }*/
}