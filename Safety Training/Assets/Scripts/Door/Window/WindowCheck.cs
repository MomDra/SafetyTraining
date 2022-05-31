using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCheck : MonoBehaviour
{
    public bool windowOpend = false;
    public float y;

    AudioSource audioSource;
    [SerializeField]
    AudioClip openClip;
    [SerializeField]
    AudioClip closeClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    void Update()
    {
        y = transform.localEulerAngles.y;

        if (y < 0f || y > 357f) // Ã¢¹® ´ÝÈû
         {
            if (windowOpend)
            {
                GameManager.Instance.EmergencyManager.IsOpenedWindow = false;
                windowOpend = false;

                audioSource.PlayOneShot(closeClip);

                Debug.Log("Ã¢¹® ´ÝÈû!");
            }
            
        }
        else
        {
            if (!windowOpend)
            {
                GameManager.Instance.EmergencyManager.IsOpenedWindow = true;
                windowOpend = true;

                audioSource.PlayOneShot(openClip);

                Debug.Log("Ã¢¹® ¿­¸²!");
            }
        }
    }
}
