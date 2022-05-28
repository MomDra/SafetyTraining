using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public UI_Object UI_INFO;

    public bool isSolved;

    /*
    public void Solve(){
        isSolved = true;
        GameManager.Instance.TaskManager.NotifySolved(this, true);
        //Debug.Log($"{UI_INFO.EducationName}: Solve() 호출");
    }

    public void NotSolve(){
        isSolved = false;
        GameManager.Instance.TaskManager.NotifySolved(this, false);
        //Debug.Log($"{UI_INFO.EducationName}: NotSolve() 호출");
    }

    protected virtual void Awake(){
        GameManager.Instance.TaskManager.RegistTask(this);
        //Debug.Log($"{UI_INFO.EducationName}: Awake() 호출!");
    }*/
}
