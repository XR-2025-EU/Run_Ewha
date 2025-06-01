using System.Diagnostics;   // Stopwatch 사용
using UnityEngine;
using TMPro;                 // TextMeshPro 텍스트를 위해 필요

public class TimeTracker : MonoBehaviour
{
    private Stopwatch stopwatch;       // 소요시간을 재는 Stopwatch
    public TMP_Text timeText;          // UI에 소요시간 표시할 TMP_Text

    private bool isTracking = false;   // 실시간 갱신 중 여부

    void Start()
    {
        stopwatch = new Stopwatch();
    }

    void Update()
    {
        if (isTracking && stopwatch.IsRunning)
        {
            int totalSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000f);
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (timeText != null)
            {
                timeText.text = string.Format("현재 소요 시간: {0:D2}분 {1:D2}초", minutes, seconds);
            }
        }
    }

    // 이동 시작
    public void StartTimer()
    {
        stopwatch.Reset();     // 이전 기록 초기화
        stopwatch.Start();     // 새로 측정 시작
        isTracking = true;     // 실시간 갱신 ON
        UnityEngine.Debug.Log("이동 시작!");
    }

    // 이동 종료
    public void StopTimer()
    {
        stopwatch.Stop();      // 측정 종료
        isTracking = false;    // 실시간 갱신 OFF

        int totalSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000f);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        UnityEngine.Debug.Log("이동시간: " + minutes + "분 " + seconds + "초");

        if (timeText != null)
        {
            timeText.text = string.Format("현재 소요 시간: {0:D2}분 {1:D2}초", minutes, seconds);
        }

        PlayerPrefs.SetFloat("이동시간", stopwatch.ElapsedMilliseconds / 1000f);
    }
}