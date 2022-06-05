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

    [SerializeField]
    AudioSource leakWarningSound;
    [SerializeField]
    AudioSource fireWarningSound;

    [SerializeField]
    UI_Manager_Hint uiManager;

    [SerializeField]
    BlurredVision blurredVision;

    [SerializeField]
    UI_Object leakUIObject;

    [SerializeField]
    UI_Object fireUIObject;

    [SerializeField]
    BreathSounds breathSound;

    IEnumerator colorCoroutine;
    IEnumerator sightCoroutine;
    IEnumerator coughCoroutine;

    bool isEmergencyStarted;
    public bool IsEmergencyStarted { get => isEmergencyStarted; }

    bool isGameEnded;


    bool isWearMask;
    public bool IsWearMask { get => IsWearMask;
        set {
            isWearMask = value;

            if (isEmergencyStarted && isWearMask)
            {
                uiManager.AddTime(90);
                StopCoroutine(sightCoroutine);
                StopCoroutine(coughCoroutine);

                breathSound.HeartBeatSoundStop();
            }

            if(isWearMask) breathSound.MaskedBreathSoundPlay();
        } 
    }

    bool isClosedValve;
    public bool IsClosedValve { get => isClosedValve;
        set
        {
            isClosedValve = value;
            if (isEmergencyStarted && isClosedValve && isOpenedWindow && !isGameEnded)
            {
                isGameEnded = true;
                SolveAccident(EmergencyType.Leak);
            }
        }
    }

    bool isOpenedWindow;

    public bool IsOpenedWindow
    {
        get => isOpenedWindow;
        set
        {
            isOpenedWindow = value;
            if (isEmergencyStarted && isOpenedWindow && isClosedValve && !isGameEnded)
            {
                isGameEnded = true;
                SolveAccident(EmergencyType.Leak);
            }
        }
    }

    

    int numFire;
    public int NumFire { get => numFire;
        set
        {
            numFire = value;
            if(numFire >= 10 && !isGameEnded)
            {
                isGameEnded = true;
                StartCoroutine(EndGameCoroutine());
                Debug.Log("���� 10���� �Ѿ���");
            }

            
            if(numFire <= 0)
            {
                SolveAccident(EmergencyType.Fire);
            }

            Debug.Log("numFire: " + numFire);
        }
    }

    private void Awake() {
        GameManager.Instance.EmergencyManager = this;

        sightCoroutine = SightEffectCoroutine();

        colorCoroutine = ColorCoroutine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            EmergencyStart(EmergencyType.Leak);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SolveAccident(EmergencyType.Leak);
        }
    }

    public void EmergencyStart(EmergencyType type)
    {
        if (isEmergencyStarted) return;

        isEmergencyStarted = true;

        
        StartCoroutine(colorCoroutine);

        switch (type)
        {
            case EmergencyType.Leak:
                uiManager.StopTimer();
                if (isWearMask) uiManager.StartTimer(120);
                else uiManager.StartTimer(30);
                uiManager.HideAllWindow();
                uiManager.ShowEmergencyWindow(type);
                if (!isWearMask)
                {
                    StartCoroutine(sightCoroutine);
                    coughCoroutine = CoughCoroutine(EmergencyType.Leak);
                    StartCoroutine(coughCoroutine);
                }
                    
                
                //leakUIObject ����
                leakUIObject.OX = "X";

                GameManager.Instance.UIManager.AddUI(ref leakUIObject);

                // ����
                leakWarningSound.Play();
             
                break;
            case EmergencyType.Fire:
                uiManager.StopTimer();
                if (isWearMask) uiManager.StartTimer(150);
                else uiManager.StartTimer(60);
                uiManager.HideAllWindow();
                uiManager.ShowEmergencyWindow(type);

                if (!isWearMask)
                {
                    coughCoroutine = CoughCoroutine(EmergencyType.Fire);
                    StartCoroutine(coughCoroutine);
                }

                // ���� ó��..
               

                fireUIObject.OX = "X";
                GameManager.Instance.UIManager.AddUI(ref fireUIObject);

                fireWarningSound.Play();

                StartCoroutine(FogCoroutine());
                
                break;
        }
    }

    IEnumerator ColorCoroutine(){
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
        }
    }

    IEnumerator SightEffectCoroutine()
    {
        yield return new WaitForSeconds(15f);
        blurredVision.StartSightEffect();
    }

    public void SolveAccident(EmergencyType type)
    {
        switch (type)
        {
            case EmergencyType.Leak:
                leakUIObject.OX = "O";
                leakWarningSound.Stop();
                break;
            case EmergencyType.Fire:
                fireUIObject.OX = "O";
                fireWarningSound.Stop();
                break;
        }

        // �÷� �ڷ�ƾ ���߱�
        StopCoroutine(colorCoroutine);


        // Ÿ�̸� ���߱�
        uiManager.StopTimer();
        
        // ui ����
        uiManager.HideAllWindow();
        uiManager.ShowSolveWindow();

        // ���� �ð� �� Fadout Scene����
        StartCoroutine(EndGameCoroutine());
    }

    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(4f);
        GameManager.Instance.EndGame();
    }

    IEnumerator CoughCoroutine(EmergencyType type)
    {
        if (isWearMask) StopCoroutine(coughCoroutine);

        yield return new WaitForSeconds(5f);
        breathSound.CoughSoundPlay();

        yield return new WaitForSeconds(10f);
        if(type == EmergencyType.Leak)
            breathSound.ShortBreathSoundPlay();
    }

    IEnumerator FogCoroutine(){

        for(int i = 0 ; i < 60; i ++){
            RenderSettings.fogDensity += 0.15f / 60f;
            yield return new WaitForSeconds(1f);
        }
        
    }

    public void HearBeatSoundPlay()
    {
        breathSound.HeartBeatSoundPlay();
    }
}
