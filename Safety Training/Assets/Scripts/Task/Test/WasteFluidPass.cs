using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteFluidPass : Task
{
    protected override void Awake()
    {
        base.Awake();
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