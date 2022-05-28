using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectSunlightPass : Task
{
    private void Awake()
    {
        GameManager.Instance.BottleManager.directSunlightPass = this;
    }
}
