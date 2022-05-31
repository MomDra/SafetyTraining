using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    UIButtonSoundManager sound;
    [SerializeField]
    bool isForward;

    private void Start()
    {
        sound = FindObjectOfType<UIButtonSoundManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isForward)
            sound.PlayForward();
        else
            sound.PlayBack();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OVRInput.SetControllerVibration(1, 0.2f, OVRInput.Controller.RTouch);
        Invoke("EndVibration", 0.2f);
    }

    void EndVibration()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
