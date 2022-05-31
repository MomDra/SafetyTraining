using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredVision : MonoBehaviour
{

    [SerializeField] Material brurredEffect;
    Renderer meshRenderer;
    private float value;

    
    public bool blurredStart = false;

    // Start is called before the first frame update
    private void Awake()
    {
        meshRenderer = GetComponent<Renderer>();
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

    /*
    IEnumerator Time()
    {
        yield return new WaitForSeconds(15f);
        meshRenderer.material = brurredEffect;
        StartCoroutine(BlurCoroutine());
    }*/

    public void StartSightEffect()
    {
        meshRenderer.material = brurredEffect;
        StartCoroutine(BlurCoroutine());
        GetComponent<AudioSource>().Play();
    }
}
