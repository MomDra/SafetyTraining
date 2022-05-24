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
            text1.text = "O";
            text1.color = Color.green;
        }
        else{
            text1.text = "X";
            text1.color = Color.red;
        }
    }

    public void UpdateText2UI(bool pass){
        if(pass){
            text2.text = "O";
            text2.color = Color.green;
        }
        else{
            text2.text = "X";
            text2.color = Color.red;
        }
    }
}
