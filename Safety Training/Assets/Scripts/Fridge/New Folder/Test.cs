using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : Task
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("EndScene");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            UI_Object newObject = new UI_Object();
            newObject.EducationType = "��ī��";
            newObject.EducationName = "���� �ڸ�����";
            newObject.OX = "O";
            GameManager.Instance.UIManager.AddUI(ref newObject);
        }
    }
}
