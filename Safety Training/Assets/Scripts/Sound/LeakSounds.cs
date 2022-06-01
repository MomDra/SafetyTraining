using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakSounds : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip coughSound;
    [SerializeField]
    AudioClip shortBreathSound;
    [SerializeField]
    AudioClip maskedBreathSound;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    
    public void CoughSoundPlay()
    {
        if (audioSource.isPlaying && audioSource.clip != coughSound)
        {
            audioSource.Stop();
            audioSource.clip = coughSound;
            audioSource.Play();
        }
    }

    public void ShortBreathSoundPlay()
    {
        if (audioSource.isPlaying && audioSource.clip != shortBreathSound)
        {
            audioSource.Stop();
            audioSource.clip = shortBreathSound;
            audioSource.Play();
        }
    }

    public void MaskedBreathSoundPlay()
    {
        if (audioSource.isPlaying && audioSource.clip != maskedBreathSound)
        {
            audioSource.Stop();
            audioSource.clip = maskedBreathSound;
            audioSource.Play();
        }
    }
}
