using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_StartScene : MonoBehaviour
{
    [SerializeField] GameObject playWindow;
    [SerializeField] GameObject exitWindow;
    [SerializeField] GameObject respondWindow;
    [SerializeField] GameObject goalWindow;

    public void ActivatePlayWindow(){
        DeActiveAllWindow();
        playWindow.SetActive(true);
    }

    public void ActiveExitWindow(){
        DeActiveAllWindow();
        exitWindow.SetActive(true);
    }

    public void ActivateRespondWindow(){
        DeActiveAllWindow();
        respondWindow.SetActive(true);
    }

    public void ActivateGoalWindow(){
        DeActiveAllWindow();
        goalWindow.SetActive(true);
    }

    public void DeActiveAllWindow(){
        playWindow.SetActive(false);
        exitWindow.SetActive(false);
        respondWindow.SetActive(false);
        goalWindow.SetActive(false);
    }

    public void StartGame(){
        SceneManager.LoadScene("Prevent2");
    }

    public void EndGame(){
        Application.Quit();
    }
}
