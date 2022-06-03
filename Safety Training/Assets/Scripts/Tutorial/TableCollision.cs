using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollision : MonoBehaviour
{
    TutorialManager manager;
    [SerializeField]
    GameObject extinguisherHandle;

    private void Awake() {
        manager = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Bottle")){
            manager.PlayAudioAndText(9);

            if(extinguisherHandle.GetComponent<OutlineOnly>() == null){
                OutlineOnly outline = extinguisherHandle.gameObject.AddComponent<OutlineOnly>();
                outline.OutlineColor = Color.magenta;
                outline.OutlineMode = OutlineOnly.Mode.OutlineAll;
            }
        }
    }
}
