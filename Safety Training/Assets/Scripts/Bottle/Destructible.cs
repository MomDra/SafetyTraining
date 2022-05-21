using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

//[RequireComponent(typeof(AudioSource))]
public class Destructible : MonoBehaviour
{
    private Rigidbody Rigidbody;
    //private AudioSource AudioSource;
    [SerializeField]
    private GameObject BrokenPrefab;
    //[SerializeField]
    //private AudioClip DestructionClip;
    [SerializeField]
    private float ExplosiveForce = 100;
    [SerializeField]
    private float ExplosiveRadius = 2;
    [SerializeField]
    private float PieceFadeSpeed = 0.25f;
    [SerializeField]
    private float PieceDestroyDelay = 5f;
    [SerializeField]
    private float PieceSleepCheckDelay = 0.1f;
    [SerializeField]
    private float DestroyingVelocity = 3;

    

    private Vector3 oldPosition;
    private Vector3 currentPosition;
    private double _velocity;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        //AudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        oldPosition = transform.position;
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
        var dis = (currentPosition - oldPosition);
        var distance = Math.Sqrt(Math.Pow(dis.x, 2) + Math.Pow(dis.y, 2) + Math.Pow(dis.z, 2));
        _velocity = distance / Time.deltaTime;
        oldPosition = currentPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(_velocity);
        if (_velocity > DestroyingVelocity && !transform.GetComponent<PutCorrectionGrabable>().isGrabbed)
        {
            Destroy(Rigidbody);
            Transform[] childList = gameObject.GetComponentsInChildren<Transform>();
            if(childList != null)
            {
                for (int i = 1; i<childList.Length; i++)
                {
                    if (childList[i] != transform)
                    {
                        Destroy(childList[i].gameObject);
                    }
                }
            }
            Destruct();
        }
    }

    public void Destruct()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;

        /*if (DestructionClip != null)
        {
            AudioSource.PlayOneShot(DestructionClip);
        }*/

        GameObject brokenInstance = Instantiate(BrokenPrefab, transform.position, transform.rotation);

        Rigidbody[] rigidbodies = brokenInstance.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody body in rigidbodies)
        {
            if (Rigidbody != null)
            {
                // inherit velocities
                body.velocity = Rigidbody.velocity;
            }
            body.AddExplosionForce(ExplosiveForce, transform.position, ExplosiveRadius);
        }

        StartCoroutine(FadeOutRigidBodies(rigidbodies));
    }

    private IEnumerator FadeOutRigidBodies(Rigidbody[] Rigidbodies)
    {
        WaitForSeconds Wait = new WaitForSeconds(PieceSleepCheckDelay);
        float activeRigidbodies = Rigidbodies.Length;

        while (activeRigidbodies > 0)
        {
            yield return Wait;

            foreach (Rigidbody rigidbody in Rigidbodies)
            {
                if (rigidbody.IsSleeping())
                {
                    activeRigidbodies--;
                }
            }
        }

        yield return new WaitForSeconds(PieceDestroyDelay);

        float time = 0;
        Renderer[] renderers = Array.ConvertAll(Rigidbodies, GetRendererFromRigidbody);

        foreach (Rigidbody body in Rigidbodies)
        {
            Destroy(body.GetComponent<Collider>());
            Destroy(body);
        }

        //깨진 조각들이 서서히 가라앉으며 사라지는 모션
        while (time < 1)
        {
            float step = Time.deltaTime * PieceFadeSpeed;
            foreach (Renderer renderer in renderers)
            {
                renderer.transform.Translate(Vector3.down * (step / renderer.bounds.size.y), Space.World);
            }

            time += step;
            yield return null;
        }

        foreach (Renderer renderer in renderers)
        {
            Destroy(renderer.gameObject);
        }
        Destroy(gameObject);
    }

    private Renderer GetRendererFromRigidbody(Rigidbody Rigidbody)
    {
        return Rigidbody.GetComponent<Renderer>();
    }

    
}