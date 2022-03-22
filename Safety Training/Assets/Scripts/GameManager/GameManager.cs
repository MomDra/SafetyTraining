using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager singleTon;

    public static GameManager Instance {get => singleTon;}

    ResourceManager resourceManager = new ResourceManager();
    public ResourceManager ResourceManager {get => resourceManager;}

    private void Awake() {
        if(singleTon != null){
            Destroy(gameObject);
            Debug.LogError("You Make 2 GameManagers");
        }

        singleTon = this;
        DontDestroyOnLoad(gameObject);
    }
}
