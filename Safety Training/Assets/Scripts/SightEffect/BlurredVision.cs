using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredVision : MonoBehaviour
{
    Renderer brurredEffect;
    Color effectColor;
    public bool blurredStart = false;

    private float blurredTime = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        brurredEffect = gameObject.GetComponent<Renderer>();
        effectColor.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Step1();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Step2();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Step3();
        }
    }

    private void Step1()
    {
        effectColor.a = 0;
        brurredEffect.material.color = effectColor;
    }

    private void Step2()
    {
        effectColor.a = 0.15f;
        brurredEffect.material.color = effectColor;
    }

    private void Step3()
    {
        effectColor.a = 0.3f;
        brurredEffect.material.color = effectColor;
    }
}
