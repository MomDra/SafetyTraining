using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;

    AudioSource audioSource;

    [SerializeField]
    GameObject startButton;
    [SerializeField]
    TextMeshProUGUI desText;
    [SerializeField]
    TextMeshProUGUI keyText;

    [SerializeField]
    UI_Tutorial_Object[] uI_Tutorial_Objects;


    int index;

    IEnumerator StartAudioCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartAudioCoroutine = StartAudio();
        StartCoroutine(StartAudioCoroutine);
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

    public void StartButton(){
        StopCoroutine(StartAudioCoroutine);
        audioSource.clip = clips[++index];
        audioSource.Play();

        startButton.SetActive(false);
        desText.gameObject.SetActive(true);
    }

    public void PlayAudioAndText(int i){
        audioSource.clip = clips[i];
        audioSource.Play();

        desText.text = uI_Tutorial_Objects[i].DesText;
        keyText.text = uI_Tutorial_Objects[i].KeyText;
    }
}
