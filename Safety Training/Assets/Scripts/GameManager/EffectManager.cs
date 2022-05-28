using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    GameObject fireEffect;

    private void Awake()
    {
        GameManager.Instance.EffectManager = this;
    }


    public void MakeFireEffect(Vector3 pos)
    {
        Instantiate(fireEffect, pos, Quaternion.identity);
    }
}
