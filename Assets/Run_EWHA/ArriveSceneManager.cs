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

            arriveTimeText.text = $"소요 시간: {minutes:D2}분 {seconds:D2}초";
            Debug.Log($"도착 씬에서 받은 시간: {minutes:D2}분 {seconds:D2}초");
        }
        else
        {
            arriveTimeText.text = "소요 시간: 정보 없음";
            Debug.Log("저장된 이동시간이 없습니다!");
        }
    }
}