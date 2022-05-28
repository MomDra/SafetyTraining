using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlammabilityPass : Task
{
    private void Awake()
    {
        GameManager.Instance.BottleManager.flammabilityPass = this;
    }


    /*
    private void Update()
    {
        if (transform.GetComponent<BottlePassCheck>().flammabilityPassCheck)
        {
            if (!isSolved)
            {
                Solve();
                Debug.Log("FlammabilityPass : Solve");
            }
        }
        else
        {
            if (isSolved)
            {
                NotSolve();
                Debug.Log("FlammabilityPass : NotSolve");
            }
        }
    }
    */
}
