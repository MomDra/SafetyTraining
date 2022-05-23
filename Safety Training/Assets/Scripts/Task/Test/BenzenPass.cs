using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BenzenPass : Task
{
    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.BottleManager.benzenPass = this;
    }

    /*
    private void Update()
    {
        if(transform.GetComponent<BottlePassCheck>().benzenPassCheck)
        {
            if (!isSolved)
            {
                Solve();
                Debug.Log("BenzenPass : Solve");
            }
        }
        else
        {
            if (isSolved)
            {
                NotSolve();
                Debug.Log("BenzenPass : NotSolve");
            }
        }
    }
    */
}
