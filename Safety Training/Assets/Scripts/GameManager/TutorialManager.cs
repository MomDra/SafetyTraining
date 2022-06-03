using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;

    AudioSource audioSource;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(StartAudio());
    }

    IEnumerator StartAudio(){
        yield return new WaitForSeconds(3f);

        for(int i = 0; i < 3; i++){
            audioSource.clip = clips[i];
            audioSource.Play();

            while(audioSource.isPlaying){
                yield return null;
            }

            index++;
        }
    }
}
