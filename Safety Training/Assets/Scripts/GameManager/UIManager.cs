using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    GameObject content;
    GameObject resultButtonPrefab;

    List<Task> tasks;
    List<bool> taskSolved;

    List<UI_Object> addedByPlayerList = new List<UI_Object>();

    public void Init(GameObject content, GameObject resultButtonPrefab){
        this.content = content;
        this.resultButtonPrefab = resultButtonPrefab;

        GameManager.Instance.ConncetUIManagerAndTaskManager(ref tasks, ref taskSolved);

        InitUI();
        MakeAddedUI();
    }

    void InitUI(){
        for(int i = 0; i < tasks.Count; i++){
            GameObject newButton = GameObject.Instantiate(resultButtonPrefab, content.transform);

            Text[] texts = newButton.GetComponentsInChildren<Text>();
            
            texts[0].text = tasks[i].UI_INFO.EducationType;
            texts[1].text = tasks[i].UI_INFO.EducationName;
            if(taskSolved[i] == true){
                texts[2].text = "O";
                texts[2].color = Color.green;
            }
            else{
                texts[2].text = "X";
                texts[2].color = Color.red;
            }
        }
    }

    public void MakeAddedUI(){
        for(int i = 0; i < addedByPlayerList.Count; i++){
            GameObject newButton = GameObject.Instantiate(resultButtonPrefab, content.transform);

            Text[] texts = newButton.GetComponentsInChildren<Text>();
            
            texts[0].text = addedByPlayerList[i].EducationType;
            texts[1].text = addedByPlayerList[i].EducationName;
            if(addedByPlayerList[i].OX.Equals("O")){
                texts[2].text = "O";
                texts[2].color = Color.green;
            }
            else{
                texts[2].text = "X";
                texts[2].color = Color.red;
            }
        }
    }

    public void AddUI(ref UI_Object UI_INFO){
        addedByPlayerList.Add(UI_INFO);
        
    }
}