using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip back;
    [SerializeField]
    AudioClip forward;
    [SerializeField]
    AudioClip scroll;


    private void Awake()
    {
        //GameManager.Instance.UIButtonSoundManager = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBack()
    {
        audioSource.PlayOneShot(back);
    }

    public void PlayForward()
    {
        audioSource.PlayOneShot(forward);
    }

    public void PlayScroll()
    {
        audioSource.PlayOneShot(scroll);
    }
}
