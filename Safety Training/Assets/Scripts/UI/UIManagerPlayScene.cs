using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerPlayScene : MonoBehaviour
{
    [SerializeField]
    GameObject menu;

    public void LoadEndScene(){
        GameManager.Instance.EndGame();
    }

    public void DeactiveMenu(){
        menu.SetActive(false);
    }

    private void Update() {
        if(OVRInput.GetDown(OVRInput.Button.Start)){
            menu.SetActive(!menu.activeSelf);
        }
    }
}
