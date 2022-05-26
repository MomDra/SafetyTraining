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
        brurredEffect.material.color = effectColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(FadeOutCoroutine());
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
