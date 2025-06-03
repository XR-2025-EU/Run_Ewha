using System.Diagnostics;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private Stopwatch stopwatch;
    public TMP_Text timeText;

    private bool isTracking = false;

    void Start()
    {
        stopwatch = new Stopwatch();

        // 이전 기록을 한 번만 불러와서 UI에 표시
        if (PlayerPrefs.HasKey("이동시간"))
        {
            float lastTime = PlayerPrefs.GetFloat("이동시간");
            int totalSeconds = (int)lastTime;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (timeText != null)
            {
                timeText.text = string.Format("이전 소요 시간: {0:D2}분 {1:D2}초", minutes, seconds);
            }
        }
    }

    void Update()
    {
        // stopwatch가 실제로 돌아가고 있을 때만 UI 갱신!
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

    // 버튼 클릭 시 호출: stopwatch 시작
    public void StartTimer()
    {
        stopwatch.Reset();
        stopwatch.Start();
        isTracking = true;
        UnityEngine.Debug.Log("이동 시작!");
    }

    // AR 인식되면 자동으로 호출: stopwatch 정지 + 결과 저장
    public void StopTimer()
    {
        if (!stopwatch.IsRunning) return;

        stopwatch.Stop();
        isTracking = false;

        float totalSeconds = stopwatch.ElapsedMilliseconds / 1000f;
        int minutes = (int)totalSeconds / 60;
        int seconds = (int)totalSeconds % 60;

        UnityEngine.Debug.Log("최종 소요시간: " + minutes + "분 " + seconds + "초");

        if (timeText != null)
        {
            timeText.text = string.Format("최종 소요 시간: {0:D2}분 {1:D2}초", minutes, seconds);
        }

        PlayerPrefs.SetFloat("이동시간", totalSeconds);
    }
}