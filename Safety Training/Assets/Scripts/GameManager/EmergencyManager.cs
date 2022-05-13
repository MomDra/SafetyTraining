using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyManager : MonoBehaviour
{
    [SerializeField] Light[] lights;



    public void EmergencyStart(){
        StartCoroutine(ColorCoroutine());
    }

    IEnumerator ColorCoroutine(){

        while(true){

            for(int i = 0; i < lights.Length; i++){
                lights[i].color = Color.red;
            }

            yield return new WaitForSeconds(0.5f);

            for(int i = 0; i < lights.Length; i++){
                lights[i].color = Color.white;
            }

            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.K)){
            EmergencyStart();
        }
    }
}
