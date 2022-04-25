using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager
{
    List<Task> tasks = new List<Task>();
    List<bool> taskSolved = new List<bool>();

    public void RegistTask(Task task){
        tasks.Add(task);
        taskSolved.Add(false);

        Debug.Log("Task 등록!");
    }

    public void NotifySolved(Task task, bool solved){
        for(int i = 0; i < tasks.Count; i++){
            if(task == tasks[i]){
                taskSolved[i] = true;
                Debug.Log("문제 해결 완료!!");
            }
        }

        EndCheck();
    }

    private void EndCheck(){
        for(int i = 0 ; i < taskSolved.Count; i++){
            if(taskSolved[i] == false) return;
        }

        //SceneManager.LoadScene(0);
        Debug.Log("모든 문제 해결 완료!");
    }
}