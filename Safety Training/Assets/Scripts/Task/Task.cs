using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    protected bool isSolved;

    protected void Solve(){
        GameManager.Instance.TaskManager.NotifySolved(this, true);
        Debug.Log("Invoke로 Solve() 호출");
    }

    protected virtual void Awake(){
        GameManager.Instance.TaskManager.RegistTask(this);

        Debug.Log("Awake() 호출!");
    }
}
