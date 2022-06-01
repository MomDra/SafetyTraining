using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathSounds : MonoBehaviour
{
    AudioSource[] audioSource;
    [SerializeField]
    AudioClip coughSound;
    [SerializeField]
    AudioClip shortBreathSound;
    [SerializeField]
    AudioClip maskedBreathSound;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponents<AudioSource>();
    }
    // Update is called once per frame
    
    public void CoughSoundPlay()
    {
        if (audioSource[0].isPlaying)
        {
            audioSource[0].Stop();
            audioSource[0].clip = coughSound;
            audioSource[0].Play();
        }
        else
        {
            audioSource[0].clip = coughSound;
            audioSource[0].Play();
        }
    }

    public void ShortBreathSoundPlay()
    {
        if (audioSource[0].isPlaying)
        {
            audioSource[0].Stop();
            audioSource[0].clip = shortBreathSound;
            audioSource[0].Play();
        }
        else
        {
            audioSource[0].clip = shortBreathSound;
            audioSource[0].Play();
        }
    }

    public void MaskedBreathSoundPlay()
    {
        if (audioSource[0].isPlaying)
        {
            audioSource[0].Stop();
            audioSource[0].clip = maskedBreathSound;
            audioSource[0].Play();
        }
        else
        {
            audioSource[0].clip = maskedBreathSound;
            audioSource[0].Play();
        }
    }

    public void HeartBeatSoundPlay()
    {
        audioSource[1].Play();
    }

    public void HeartBeatSoundStop()
    {
        audioSource[1].Stop();
    }
}
