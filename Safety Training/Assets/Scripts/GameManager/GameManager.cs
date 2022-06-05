using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager singleTon;

    public static GameManager Instance {get => singleTon;}

    ResourceManager resourceManager = new ResourceManager();
    public ResourceManager ResourceManager {get => resourceManager;}

    /*
    TaskManager taskManager = new TaskManager();
    public TaskManager TaskManager {get => taskManager;}*/

    EmergencyManager emergencyManager;
    public EmergencyManager EmergencyManager { get => emergencyManager; set => emergencyManager = value; }

    UIManager uiManager = new UIManager();
    public UIManager UIManager {get => uiManager;}

    BottleManager bottleManager = new BottleManager();
    public BottleManager BottleManager {get => bottleManager;}

    EffectManager effectManager;
    public EffectManager EffectManager { get => effectManager; set => effectManager = value; }

    int time;
    public int Time { get => time; set => time = value; }

    bool isEnded;
    public bool IsEnded { get => isEnded; set => isEnded = value; }

    bool isGameEnded;

    [SerializeField]
    bool isPrevent;

    private void Awake() {
        if(singleTon != null){
            singleTon.Init();
            Destroy(gameObject);
            Debug.LogError("You Make 2 GameManagers");
        }
        else
        {
            singleTon = this;
            singleTon.Init();
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            EndGame();
        }
    }

    void Init()
    {
        bottleManager.Init();
        uiManager.InitList();
        singleTon.isGameEnded = false;
    }

    /*
    public void ConncetUIManagerAndTaskManager(ref List<Task> task, ref List<bool> tasksolved){
        task = taskManager.GetTask();
        tasksolved = taskManager.GetTaskSolved();
    }*/

    public void EndGame()
    {
        if(!isGameEnded){
            isGameEnded = true;
            OVRScreenFade.instance.FadeOut();

            if(isPrevent)
                BottleManager.ShowUI();

            Invoke("LoadEndScene", 4f);
        }
        
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
