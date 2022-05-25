using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyManager : MonoBehaviour
{
    [SerializeField] Light[] lights;
    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }


    public void EmergencyStart(){
        StartCoroutine(ColorCoroutine());
        audioSource.Play();
    }

    IEnumerator ColorCoroutine(){
        int n = 0;

        while(true){

            for(int i = 0; i < lights.Length; i++){
                lights[i].color = Color.red;
                lights[i].intensity = 5f;
            }

            yield return new WaitForSeconds(0.5f);

            for(int i = 0; i < lights.Length; i++){
                lights[i].color = Color.white;
                lights[i].intensity = 1f;
            }

            yield return new WaitForSeconds(0.5f);

            n++;

            if(n >= 11) break;
        }
        
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.K)){
            EmergencyStart();
        }
    }
}
