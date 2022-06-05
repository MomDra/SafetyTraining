using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPrevent : MonoBehaviour
{
    private void Awake() {
        GameManager.Instance.IsPrevent = true;
    }
}
