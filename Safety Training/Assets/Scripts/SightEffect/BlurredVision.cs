using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredVision : MonoBehaviour
{
    Renderer brurredEffect;
    Color effectColor = Color.black;
    public bool blurredStart = false;

    private float blurredTime = 0f;

    IEnumerator timeCoroutine;

    // Start is called before the first frame update
    private void Awake()
    {
        brurredEffect = gameObject.GetComponent<Renderer>();
        effectColor.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            //Debug.Log("fade1 0~0.2");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine("Fade2");
            //Debug.Log("fade2 0.2~0.4");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine("Fade3");
            //Debug.Log("fade3 0.4~0.2");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine("Fade4");
            //Debug.Log("fade4 0.2~0");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(FadeOutCoroutine());
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

    IEnumerator FadeOutCoroutine()
    {
        Color color = brurredEffect.material.color;

        for (int i = 0; i < 1000; i++)
        {
            color.a += 0.001f;

            brurredEffect.material.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.LoadEndScene();
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(15f);
        StartCoroutine("Fade1");

        yield return new WaitForSeconds(15f);
        StartCoroutine("Fade2");
    }

    public void StartSightEffect()
    {
        timeCoroutine = Time();
        StartCoroutine(timeCoroutine);
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine("FadeOutCoroutine");
    }
}
