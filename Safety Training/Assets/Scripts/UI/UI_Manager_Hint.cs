using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Manager_Hint : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text1;
    [SerializeField]
    TextMeshProUGUI text2;
    [SerializeField]
    TextMeshProUGUI ox1;
    [SerializeField]
    TextMeshProUGUI ox2;
    [SerializeField]
    TextMeshProUGUI timeText;

    [SerializeField]
    GameObject hint;
    [SerializeField]
    GameObject emergency;
    [SerializeField]
    GameObject solve;

    [SerializeField]
    int time;

    IEnumerator coroutine;

    private void Awake() {
        GameManager.Instance.BottleManager.RegistHint(this);
    }

    private void Start()
    {
        coroutine = CountDown();
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
    public IEnumerator CountDown()
    {
        while (time >= 0)
        {
            UPdateTimeUI(time);
            time--;
            GameManager.Instance.Time = time;

            if (time == 5) GameManager.Instance.EmergencyManager.HearBeatSoundPlay();

            yield return new WaitForSeconds(1f);
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
        coroutine = CountDown();
        StartCoroutine(coroutine);
    }

    public void AddTime(int time)
    {
        this.time += time;
    }

    public void HideAllWindow()
    {
        hint.SetActive(false);
        emergency.SetActive(false);
        solve.SetActive(false);
    }

    public void ShowEmergencyWindow(EmergencyType type)
    {
        switch (type)
        {
            case EmergencyType.Leak:
                emergency.GetComponentInChildren<TextMeshProUGUI>().text = "가스가 누출되었습니다.";
                break;
            case EmergencyType.Fire:
                emergency.GetComponentInChildren<TextMeshProUGUI>().text = "화재가 발생하였습니다.";
                break;
        }

        emergency.SetActive(true);
    }

    public void ShowSolveWindow()
    {
        solve.SetActive(true);
    }
}
