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
    OVRGrabbable grabbable;

    AudioSource audioSource;

    [SerializeField]
    AudioClip fireExtingusherSound;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        grabbable = GetComponentInChildren<OVRGrabbable>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float prevFlex = m_prevFlex;
        // Update values from inputs
        m_prevFlex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller);

        //Debug.Log(prevFlex);

        FireCheck(prevFlex);
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
        if (grabbable.isGrabbed)
        {
            particle.Play();

            audioSource.Play();
        }
    }

    protected void FireEnd()
    {
        particle.Stop();

        audioSource.Stop();
    }
}
