using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager
{
    GameObject content;
    GameObject resultButtonPrefab;

    List<UI_Object> addedByPlayerList;

    Image reasonImg;
    TextMeshProUGUI reasonText;
    Image accidentImg;
    TextMeshProUGUI accidentDescription;
    TextMeshProUGUI accidentScale;
    TextMeshProUGUI accidentConutermeasure;

    public void Init(GameObject content, GameObject resultButtonPrefab, Image reasonImg, TextMeshProUGUI reasonText, Image accidentImg, TextMeshProUGUI accidentDescription, TextMeshProUGUI accidentScale, TextMeshProUGUI accidentConutermeasure){
        this.content = content;
        this.resultButtonPrefab = resultButtonPrefab;
        this.reasonImg = reasonImg;
        this.reasonText = reasonText;
        this.accidentImg = accidentImg;
        this.accidentDescription = accidentDescription;
        this.accidentScale = accidentScale;
        this.accidentConutermeasure = accidentConutermeasure;


        //InitUI();
        MakeAddedUI();
    }

    public void InitList()
    {
        addedByPlayerList = new List<UI_Object>();
    }

    /*
    void InitUI(){
        for(int i = 0; i < tasks.Count; i++){
            GameObject newButton = GameObject.Instantiate(resultButtonPrefab, content.transform);

            TextMeshProUGUI[] texts = newButton.GetComponentsInChildren<TextMeshProUGUI>();
            
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

            UI_Object info = tasks[i].UI_INFO;
            newButton.GetComponent<Button>().onClick.AddListener(() => MakeReasonAndAccident(info));
        }
    }*/

    private void MakeAddedUI(){
        for(int i = 0; i < addedByPlayerList.Count; i++){
            GameObject newButton = GameObject.Instantiate(resultButtonPrefab, content.transform);

            TextMeshProUGUI[] texts = newButton.GetComponentsInChildren<TextMeshProUGUI>();
            
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

            UI_Object info = addedByPlayerList[i];
            newButton.GetComponent<Button>().onClick.AddListener(() => MakeReasonAndAccident(info));
        }
    }

    public void AddUI(ref UI_Object UI_INFO){
        addedByPlayerList.Add(UI_INFO);
    }

    void MakeReasonAndAccident(UI_Object UI_INFO){
        if(UI_INFO.ReasonImg == null){
            reasonImg.sprite = null;
            reasonImg.color = Color.clear;
        }
        else{
            reasonImg.sprite = UI_INFO.ReasonImg;
            reasonImg.color = Color.white;
        }

        if(UI_INFO.ResasonText.Equals("") || UI_INFO.ResasonText == null){
            reasonText.text = "";
        }
        else{
            reasonText.text = UI_INFO.ResasonText;
        }

        if(UI_INFO.AccidentImg == null){
            accidentImg.sprite = null;
            accidentImg.color = Color.clear;
        }
        else{
            accidentImg.sprite = UI_INFO.AccidentImg;
            accidentImg.color = Color.white;
        }

        if(UI_INFO.AccidentDescription.Equals("") || UI_INFO.AccidentDescription == null){
            accidentDescription.text = "";
        }
        else{
            accidentDescription.text = UI_INFO.AccidentDescription;
        }

        if(UI_INFO.AccidentScale.Equals("") || UI_INFO.AccidentScale == null){
            accidentScale.text = "";
        }
        else{
            accidentScale.text = UI_INFO.AccidentScale;
        }

        if(UI_INFO.AccidentCountermeasure.Equals("") || UI_INFO.AccidentCountermeasure == null){
            accidentConutermeasure.text = "";
        }
        else{
            accidentConutermeasure.text = UI_INFO.AccidentCountermeasure;
        }
        
    }
}