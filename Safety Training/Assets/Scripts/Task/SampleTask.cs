using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleTask : Task
{
    protected override void Awake() {
        base.Awake();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.A)){
            Solve();
        }

        if(Input.GetKeyDown(KeyCode.B)){
            SceneManager.LoadScene("EndScene");
        }

        if(Input.GetKeyDown(KeyCode.C)){
            UI_Object newObject = new UI_Object();
            newObject.EducationType = "스카이";
            newObject.EducationName = "보다 코리아텍";
            newObject.OX = "O";
            GameManager.Instance.UIManager.AddUI(ref newObject);
        }
    }
}
