using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField]
    protected OVRInput.Controller m_controller;

    float m_prevFlex;

    float grabBegin = 0.55f;
    float grabEnd = 0.35f;

    ParticleSystem particle;
    PutCorrectionGrabable grabbable;

    AudioSource audioSource;

    [SerializeField]
    AudioClip fireExtingusherSound;

    IEnumerator coroutine;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        grabbable = GetComponentInChildren<PutCorrectionGrabable>();
        audioSource = GetComponent<AudioSource>();

        coroutine = VibrationCoroutine();

        grabbable.grabEndEvent.AddListener(FireEnd);
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed)
        {
            float prevFlex = m_prevFlex;
            // Update values from inputs
            m_prevFlex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller);

            FireCheck(prevFlex);
        }
    }

    public void FireCheck(float prevFlex)
    {
        if ((m_prevFlex >= grabBegin) && (prevFlex < grabBegin))
        {
            FireBegin();
        }
        else if ((m_prevFlex <= grabEnd) && (prevFlex > grabEnd))
        {
            FireEnd();
        }
    }

    protected void FireBegin()
    {
        particle.Play();
        audioSource.Play();

        StartCoroutine(coroutine);
    }

    protected void FireEnd()
    {
        particle.Stop();
        audioSource.Stop();

        StopCoroutine(coroutine);

        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }

    IEnumerator VibrationCoroutine()
    {
        while (true)
        {
            OVRInput.SetControllerVibration(1f, 0.2f, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(1f, 0.2f, OVRInput.Controller.RTouch);

            yield return new WaitForSeconds(2f);
        }
    }
}
