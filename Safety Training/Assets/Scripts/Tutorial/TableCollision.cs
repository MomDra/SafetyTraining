using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollision : MonoBehaviour
{
    TutorialManager manager;
    [SerializeField]
    GameObject extinguisherHandle;
    
    bool trigger;

    private void Awake() {
        manager = FindObjectOfType<TutorialManager>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Bottle") && !trigger && manager.Index == 9){
            trigger = true;

            manager.PlayAudioAndText(9);

            if(extinguisherHandle.GetComponent<OutlineOnly>() == null){
                OutlineOnly outline = extinguisherHandle.gameObject.AddComponent<OutlineOnly>();
                outline.OutlineColor = Color.magenta;
                outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
            }

            if(GetComponent<OutlineOnly>() != null){
                Destroy(GetComponent<OutlineOnly>());
            }
        }
    }
}
