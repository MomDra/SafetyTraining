using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmergencyType
{
    Leak,
    Fire
}


public class EmergencyManager : MonoBehaviour
{
    [SerializeField] Light[] lights;
    AudioSource audioSource;

    [SerializeField]
    UI_Manager_Hint uiManager;

    [SerializeField]
    BlurredVision blurredVision;

    [SerializeField]
    UI_Object leakUIObject;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void EmergencyStart(EmergencyType type)
    {
        StartCoroutine(ColorCoroutine());
        audioSource.Play();

        switch (type)
        {
            case EmergencyType.Leak:
                uiManager.StopTimer();
                uiManager.StartTimer(120);
                uiManager.HideAllWindow();
                uiManager.ShowLeakWindow();
                blurredVision.StartSightEffect();

                //leakUIObject ¼³Á¤

                GameManager.Instance.UIManager.AddUI(ref leakUIObject);
                break;
            case EmergencyType.Fire:

                break;
        }
    }

    IEnumerator ColorCoroutine(){
        int n = 0;

        while(true){

            for(int i = 0; i < lights.Length; i++){
                lights[i].color = Color.red;
                lights[i].intensity = 5f;
            }

            yield return new WaitForSeconds(0.5f);

            for(int i = 0; i < lights.Length; i++){
                lights[i].color = Color.white;
                lights[i].intensity = 1f;
            }

            yield return new WaitForSeconds(0.5f);

            n++;

            if(n >= 11) break;
        }
        
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.K)){
            EmergencyStart(EmergencyType.Leak);
        }
    }
}
