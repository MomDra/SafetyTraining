using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager_EndScene : MonoBehaviour
{
    [SerializeField] GameObject resultWindow;
    [SerializeField] GameObject exitWindow;
    [SerializeField] GameObject content;
    [SerializeField] GameObject ResultButtonPrefab;
    [SerializeField] Image reasonImg;
    [SerializeField] TextMeshProUGUI reasonText;
    [SerializeField] Image accidentImg;
    [SerializeField] TextMeshProUGUI accidentDescription;
    [SerializeField] TextMeshProUGUI accidentScale;
    [SerializeField] TextMeshProUGUI accidentCountermeasure;

    private void Awake() {
        GameManager.Instance.UIManager.Init(content, ResultButtonPrefab, reasonImg, reasonText, accidentImg, accidentDescription, accidentScale, accidentCountermeasure);
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
