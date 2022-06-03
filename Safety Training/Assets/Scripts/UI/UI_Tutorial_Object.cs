using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UI_Tutorial_Object", menuName = "Safety Training/UI_Tutorial_Object", order = 0)]
public class UI_Tutorial_Object : ScriptableObject {
    [SerializeField]
    string desText;
    public string DesText{get => desText; set => desText = value;}

    [SerializeField]
    string keyText;
    public string KeyText{get => keyText; set => keyText = value;}
}
