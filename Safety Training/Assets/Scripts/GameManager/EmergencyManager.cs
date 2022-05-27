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

    bool isEmergencyStarted;

    bool isWearMask;
    public bool IsWearMask { get => IsWearMask;
        set {
            isWearMask = true;

            if (isEmergencyStarted)
            {

            }
        } 
    }

    private void Awake() {
        GameManager.Instance.EmergencyManager = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void EmergencyStart(EmergencyType type)
    {
        isEmergencyStarted = true;

        audioSource.Play();
        StartCoroutine(ColorCoroutine());
        

        switch (type)
        {
            case EmergencyType.Leak:
                uiManager.StopTimer();
                if (isWearMask) uiManager.StartTimer(120);
                else uiManager.StartTimer(30);
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

    public void SolveAccident()
    {
        uiManager.HideAllWindow();
        uiManager.ShowSolveWindow();
    }

    public void WearMask()
    {
        isWearMask = true;
    }

    public void FadeOut()
    {
        blurredVision.FadeOut();
    }
}
