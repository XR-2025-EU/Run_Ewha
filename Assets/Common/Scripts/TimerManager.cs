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
        timerText.text = $"���� �ҿ� �ð� : {m:D2}�� {s:D2}��";
    }
}