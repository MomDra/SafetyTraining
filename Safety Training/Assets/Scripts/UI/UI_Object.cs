using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UI_Object", menuName = "Safety Training/UI_Object", order = 0)]
public class UI_Object : ScriptableObject {
    
    [SerializeField]
    string educationType;
    public string EducationType {get=>educationType; set => educationType=value;}

    [SerializeField]
    string educationName;
    public string EducationName {get => educationName; set=>educationName=value;}

    [SerializeField]
    string ox;
    public string OX {get => ox; set => ox = value;}

    [SerializeField]
    Sprite reasonImg;
    public Sprite ReasonImg {get => reasonImg; set => reasonImg = value;}

    [SerializeField]
    string reasonText;
    public string ResasonText {get => reasonText; set => reasonText = value;}

    [SerializeField]
    Sprite accidentImg;
    public Sprite AccidentImg {get => accidentImg; set => accidentImg = value;}

    [SerializeField] [TextArea]
    string accidentDescription;
    public string AccidentDescription {get => accidentDescription; set => accidentDescription = value;}

    [SerializeField] [TextArea]
    string accidentScale;
    public string AccidentScale {get => accidentScale; set => accidentScale = value;}

    [SerializeField] [TextArea]
    string accidentConutermeasure;
    public string AccidentCountermeasure {get => accidentConutermeasure; set => accidentConutermeasure = value;}



}
