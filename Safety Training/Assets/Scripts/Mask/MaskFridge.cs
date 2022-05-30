using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskFridge : MonoBehaviour
{
    bool isOpened;

    [SerializeField]
    AudioClip closeClip;
    [SerializeField]
    AudioClip openClip;


    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(transform.localRotation.eulerAngles.y < 3f || transform.localRotation.y > 357f) // ���� ����
        {
            if (isOpened)
            {
                isOpened = false;
                source.PlayOneShot(closeClip);

                Debug.Log("����" + transform.localRotation.eulerAngles.y);
            }
        }
        else // ���� ����
        {
            if (!isOpened)
            {
                isOpened = true;
                source.PlayOneShot(openClip);

                Debug.Log("����" +transform.localRotation.eulerAngles.y);
            }
        }
    }
}
