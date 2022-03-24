using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick_MainMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject exitMenu;
    public GameObject mainMenu;
    public GameObject prevMenu;

    public void prev_btn_clicked()
    {
        mainMenu.SetActive(false);
        prevMenu.SetActive(true);

    }
    public void prev_back_clicked()
    {
        prevMenu.SetActive(false);
        mainMenu.SetActive(true);

    }

    public void exitMenu_btn_clicked()
    {
        mainMenu.SetActive(false);
        exitMenu.SetActive(true);
    }
    public void exitMenu_back_clicked()
    {
        exitMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void option_btn_clicked()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    public void option_back_clicked()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
