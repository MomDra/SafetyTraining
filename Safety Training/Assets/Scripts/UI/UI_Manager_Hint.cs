using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_Hint : MonoBehaviour
{
    [SerializeField]
    Text text1;
    [SerializeField]
    Text text2;
    [SerializeField]
    Text ox1;
    [SerializeField]
    Text ox2;

    private void Awake() {
        GameManager.Instance.BottleManager.RegistHint(this);
    }

    public void UpdateText1UI(bool pass){
        if(pass){
            ox1.text = "O";
            ox1.color = Color.green;
        }
        else{
            ox1.text = "X";
            ox1.color = Color.red;
        }
    }

    public void UpdateText2UI(bool pass){
        if(pass){
            ox2.text = "O";
            ox2.color = Color.green;
        }
        else{
            ox2.text = "X";
            ox2.color = Color.red;
        }
    }
}
