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
        effectColor.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine("Fade1");
            Debug.Log("fade1 0~0.2");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine("Fade2");
            Debug.Log("fade2 0.2~0.4");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine("Fade3");
            Debug.Log("fade3 0.4~0.2");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine("Fade4");
            Debug.Log("fade4 0.2~0");
        }
    }

    IEnumerator Fade1()
    {
        for (float f = 0f; f <= 0.2f; f += 0.01f)
        {
            effectColor.a = f;
            brurredEffect.material.color = effectColor;
            yield return null;
        }
    }

    IEnumerator Fade2()
    {
        for (float f = 0.2f; f <= 0.4f; f += 0.01f)
        {
            effectColor.a = f;
            brurredEffect.material.color = effectColor;
            yield return null;
        }
    }

    IEnumerator Fade3()
    {
        for (float f = 0.4f; f >= 0.2f; f -= 0.01f)
        {
            effectColor.a = f;
            brurredEffect.material.color = effectColor;
            yield return null;
        }
    }

    IEnumerator Fade4()
    {
        for (float f = 0.2f; f >= 0; f -= 0.01f)
        {
            effectColor.a = f;
            brurredEffect.material.color = effectColor;
            yield return null;
        }
    }

}
