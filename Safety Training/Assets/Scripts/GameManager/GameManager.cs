using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager singleTon;

    public static GameManager Instance {get => singleTon;}

    ResourceManager resourceManager = new ResourceManager();
    public ResourceManager ResourceManager {get => resourceManager;}

    TaskManager taskManager = new TaskManager();
    public TaskManager TaskManager {get => taskManager;}

    EmergencyManager emergencyManager;
    public EmergencyManager EmergencyManager {get => emergencyManager;}

    UIManager uiManager = new UIManager();
    public UIManager UIManager {get => uiManager;}

    BottleManager bottleManager = new BottleManager();
    public BottleManager BottleManager {get => bottleManager;}


    private void Awake() {
        if(singleTon != null){
            Destroy(gameObject);
            Debug.LogError("You Make 2 GameManagers");
        }

        singleTon = this;
        DontDestroyOnLoad(gameObject);

        emergencyManager = GetComponent<EmergencyManager>();
    }

    public void ConncetUIManagerAndTaskManager(ref List<Task> task, ref List<bool> tasksolved){
        task = taskManager.GetTask();
        tasksolved = taskManager.GetTaskSolved();
    }
}
