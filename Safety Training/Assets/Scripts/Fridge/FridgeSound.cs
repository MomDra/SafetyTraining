using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeSound : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip openClip;
    [SerializeField]
    AudioClip closeClip;
    [SerializeField]
    bool isLeft;
    [SerializeField]
    bool isFlammabilityFridge;

    bool isOpended;

    void Update()
    {
        if (isFlammabilityFridge)
        {
            Debug.Log(transform.eulerAngles.y);

            if(transform.localEulerAngles.y < 0f || transform.localEulerAngles.y > 357f) // ¥›«Ù ¿÷¿Ω
            {
                if (isOpended)
                {
                    isOpended = false;
                    PlayCloseSound();

                    Debug.Log("¥›»˚: " + transform.eulerAngles.y);
                }
            }
            else // ø≠∑¡ ¿÷¿Ω
            {
                if (!isOpended)
                {
                    isOpended = true;
                    PlayOpenSound();

                    Debug.Log("ø≠∏≤: " + transform.eulerAngles.y);
                }
            }
        }
        else
        {
            if (isLeft)
            {
                if (transform.eulerAngles.y < 273f && transform.eulerAngles.y > 40f) // ¥›«Ù ¿÷¿Ω
                {
                    if (isOpended)
                    {
                        isOpended = false;
                        PlayCloseSound();

                        Debug.Log("¥›»˚: " + transform.eulerAngles.y);
                    }
                }
                else
                {
                    if (!isOpended)
                    {
                        isOpended = true;
                        PlayOpenSound();

                        Debug.Log("ø≠∏≤: " + transform.eulerAngles.y);
                    }
                }
            }
            else
            {
                if (transform.eulerAngles.y > 267f) // ¥›«Ù ¿÷¿Ω
                {
                    if (isOpended)
                    {
                        isOpended = false;
                        PlayCloseSound();

                        Debug.Log("¥›»˚: " + transform.eulerAngles.y);
                    }
                }
                else
                {
                    if (!isOpended)
                    {
                        isOpended = true;
                        PlayOpenSound();

                        Debug.Log("ø≠∏≤: " + transform.eulerAngles.y);
                    }
                }
            }
        }
    }

    void PlayOpenSound()
    {
        audioSource.PlayOneShot(openClip);
    }

    void PlayCloseSound()
    {
        audioSource.PlayOneShot(closeClip);
    }
}
