using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_Hint : MonoBehaviour
{
    [SerializeField]
    Text text1;
    [SerializeField]
    Text text2;
    [SerializeField]
    Text ox1;
    [SerializeField]
    Text ox2;
    [SerializeField]
    Text timeText;

    [SerializeField]
    GameObject hint;
    [SerializeField]
    GameObject leak;

    [SerializeField]
    int time;

    IEnumerator coroutine;

    private void Awake() {
        GameManager.Instance.BottleManager.RegistHint(this);
    }

    private void Start()
    {
        coroutine = CountDown(time);
        StartCoroutine(coroutine);
    }

    public void UpdateText1UI(bool pass){
        if(pass){
            ox1.text = "O";
            ox1.color = Color.green;
        }
        else{
            ox1.text = "X";
            ox1.color = Color.red;
        }
    }

    public void UpdateText2UI(bool pass){
        if(pass){
            ox2.text = "O";
            ox2.color = Color.green;
        }
        else{
            ox2.text = "X";
            ox2.color = Color.red;
        }
    }
    public IEnumerator CountDown(int time)
    {
        Debug.Log("코루틴 시작: " + time);

        while (time >= 0)
        {
            Debug.Log("while 시작: " + time);

            UPdateTimeUI(time);
            time--;
            GameManager.Instance.Time = time;

            yield return new WaitForSeconds(1f);

            Debug.Log("while 끝: " + time);
        }

        GameManager.Instance.EndGame();
    }

    void UPdateTimeUI(int n)
    {
        if (n < 10) timeText.color = Color.red;
        timeText.text = $"남은 시간: {n}";
    }

    public void StopTimer()
    {
        StopCoroutine(coroutine);
    }

    public void StartTimer(int time)
    {
        this.time = time;
        coroutine = CountDown(time);
        StartCoroutine(coroutine);
    }

    public void HideAllWindow()
    {
        hint.SetActive(false);
        leak.SetActive(false);
    }

    public void ShowLeakWindow()
    {
        leak.SetActive(true);
    }
}
