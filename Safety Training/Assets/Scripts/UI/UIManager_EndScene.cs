using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_EndScene : MonoBehaviour
{
    [SerializeField] GameObject resultWindow;
    [SerializeField] GameObject exitWindow;
    [SerializeField] GameObject content;
    [SerializeField] GameObject ResultButtonPrefab;

    private void Awake() {
        GameManager.Instance.UIManager.Init(content, ResultButtonPrefab);
    }

    public void DeactivateAllWindow(){
        resultWindow.SetActive(false);
        exitWindow.SetActive(false);
    }
    

    public void ReStart(){
        SceneManager.LoadScene("StartScene");
    }

    public void ActivateResultWindow(){
        DeactivateAllWindow();
        resultWindow.SetActive(true);
    }

    public void ActivateExitWindow(){
        DeactivateAllWindow();
        exitWindow.SetActive(true);
    }

    public void EndGame(){
        Application.Quit();
    }
}
