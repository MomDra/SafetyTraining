using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredVision : MonoBehaviour
{

    [SerializeField] Material brurredEffect;
    [SerializeField] Material fadeOutEffect;
    Color effectColor = Color.black;
    Renderer meshRenderer;
    private float value;
    
    public bool blurredStart = false;

    private float blurredTime = 0f;

    IEnumerator timeCoroutine;
    
    // Start is called before the first frame update
    private void Awake()
    {
        meshRenderer = GetComponent<Renderer>();
       // brurredEffect.enabled = false;
        //fadeOutEffect.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))//Å×½ºÆ®
        {
            meshRenderer.material = brurredEffect;
            StartCoroutine(BlurCoroutine());
        }
    }
    IEnumerator BlurCoroutine()
    {
        value = 0f;

        for (int i = 0; i < 1000; i++)
        {
            value += 0.004f/1000f;
            
            yield return null;
            brurredEffect.SetFloat("_Value", value);
        }
    }

    IEnumerator FadeOutCoroutine()
    {
        /*Color color = brurredEffect.material.color;

        for (int i = 0; i < 1000; i++)
        {
            color.a += 0.001f;

            brurredEffect.material.color = color;
            yield return null;
        }*/

        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.LoadEndScene();
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(15f);
        meshRenderer.material = brurredEffect;
        StartCoroutine(BlurCoroutine());
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
