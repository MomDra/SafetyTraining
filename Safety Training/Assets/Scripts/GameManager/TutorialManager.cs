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

    [SerializeField]
    GameObject pauseWindow;

    [SerializeField]
    GameObject uiHelper;

    [SerializeField]
    GameObject bottle;

    bool leftSettingKey1;
    bool leftSettingKey2;


    int index;

    IEnumerator StartAudioCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartAudioCoroutine = StartAudio();
        StartCoroutine(StartAudioCoroutine);

        index = 3;
    }

    private void Update() {
        if(leftSettingKey1 && OVRInput.GetDown(OVRInput.Button.Start)){
            pauseWindow.SetActive(true);

            PlayAudioAndText(4);
            index = 5;

            leftSettingKey1 = false;
            leftSettingKey2 = true;
        }
        else if(leftSettingKey2 && OVRInput.GetDown(OVRInput.Button.Start)){
            pauseWindow.SetActive(false);
            PlayAudioAndText(5);
            index = 6;
            leftSettingKey2 = false;

            if(bottle.GetComponent<OutlineOnly>() == null){
                OutlineOnly outline = bottle.AddComponent<OutlineOnly>();
                outline.OutlineColor = Color.magenta;
                outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
            }
        }
    }

    IEnumerator StartAudio(){
        yield return new WaitForSeconds(3f);

        for(int i = 0; i < 3; i++){
            PlayAudioAndText(i);

            while(audioSource.isPlaying){
                yield return null;
            }
        }

        uiHelper.SetActive(true);
    }

    public void StartButton(){
        StopCoroutine(StartAudioCoroutine);
        PlayAudioAndText(3);
        index = 4;

        startButton.SetActive(false);
        uiHelper.SetActive(false);

        leftSettingKey1 = true;
    }

    public void PlayAudioAndText(int i){
        index = i + 1;
        audioSource.clip = clips[i];
        audioSource.Play();

        //desText.text = uI_Tutorial_Objects[i].DesText;
        //keyText.text = uI_Tutorial_Objects[i].KeyText;
    }
}
