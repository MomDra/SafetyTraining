using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour
{
    int cnt;
    bool trigger;

    TutorialManager manager;
    [SerializeField]
    GameObject table;

    private void Awake() {
        manager = FindObjectOfType<TutorialManager>();
    }

    private void OnParticleCollision(GameObject other) {
        if(other.CompareTag("CheckParticle")){
            cnt++;

            if(cnt > 100 && !trigger){
                trigger = true;
                manager.PlayAudioAndText(8);

                if(table.GetComponent<OutlineOnly>() == null){
                    OutlineOnly outline = table.gameObject.AddComponent<OutlineOnly>();
                    outline.OutlineColor = Color.magenta;
                    outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
                }
            }
        }
    }
}
