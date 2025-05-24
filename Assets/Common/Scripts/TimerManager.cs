using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TMP_Text timerText;
    private float elapsed;

    void Update()
    {
        elapsed += Time.deltaTime;
        int m = (int)(elapsed / 60);
        int s = (int)(elapsed % 60);
        timerText.text = $"현재 소요 시간 : {m:D2}분 {s:D2}초";
    }
}