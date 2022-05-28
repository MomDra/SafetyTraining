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
        Quaternion rot = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);

        Instantiate(fireEffect, pos, rot);
    }
}
