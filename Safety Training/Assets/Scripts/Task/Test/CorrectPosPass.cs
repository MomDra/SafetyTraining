using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectPosPass : Task
{
    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.BottleManager.correctPosPass = this;
    }

    /*
    private void Update()
    {
        if (transform.GetComponent<BottlePassCheck>().correctPosPassCheck)
        {
            if (!isSolved)
            {
                Solve();
                Debug.Log("CorrectPosPass : Solve");
            }
        }
        else
        {
            if (isSolved)
            {
                NotSolve();
                Debug.Log("CorrectPosPass : NotSolve");
            }
        }
    }
    */
}
