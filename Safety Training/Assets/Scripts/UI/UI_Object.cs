using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
