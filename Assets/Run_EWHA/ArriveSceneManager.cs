using UnityEngine;
using TMPro;

public class ArriveSceneManager : MonoBehaviour
{
    public TMP_Text arriveTimeText; // Inspector에서 연결

    void Start()
    {
        if (PlayerPrefs.HasKey("이동시간"))
        {
            float totalSeconds = PlayerPrefs.GetFloat("이동시간");
            int minutes = (int)totalSeconds / 60;
            int seconds = (int)totalSeconds % 60;

            arriveTimeText.text = $"{minutes:D2}m {seconds:D2}s";
            Debug.Log($"도착 씬에서 받은 시간: {minutes:D2}m {seconds:D2}s");
        }
        else
        {
            arriveTimeText.text = "정보 없음";
            Debug.Log("저장된 이동시간이 없습니다!");
        }
    }
}