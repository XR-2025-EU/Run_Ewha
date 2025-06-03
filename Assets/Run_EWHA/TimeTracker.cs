using UnityEngine;
using TMPro;
using System.Diagnostics;

public class TimeTracker : MonoBehaviour
{
    private Stopwatch stopwatch;
    public TMP_Text timeText;

    private bool isTracking = false;

    void Start()
    {
        stopwatch = new Stopwatch();

        // 다음 씬에서 이전 소요시간 불러오기
        if (PlayerPrefs.HasKey("이동시간"))
        {
            float lastTime = PlayerPrefs.GetFloat("이동시간");
            int totalSeconds = (int)lastTime;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (timeText != null)
            {
                timeText.text = string.Format("현재 소요 시간: {0:D2}분 {1:D2}초", minutes, seconds);
            }
        }
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

    // 시작 버튼에서 이 함수만 호출
    public void StartTimer()
    {
        stopwatch.Reset();
        stopwatch.Start();
        isTracking = true;
        UnityEngine.Debug.Log("이동 시작!");  // UnityEngine.Debug로 명시
    }

    // AR 카메라에서 대상 인식되면 이 함수 자동 호출!
    public void StopTimer()
    {
        if (!stopwatch.IsRunning) return;

        stopwatch.Stop();
        isTracking = false;

        float totalSeconds = stopwatch.ElapsedMilliseconds / 1000f;
        int minutes = (int)totalSeconds / 60;
        int seconds = (int)totalSeconds % 60;

        UnityEngine.Debug.Log("최종 소요시간: " + minutes + "분 " + seconds + "초");  // UnityEngine.Debug로 명시

        if (timeText != null)
        {
            timeText.text = string.Format("현재 소요 시간: {0:D2}분 {1:D2}초", minutes, seconds);
        }

        // PlayerPrefs에 저장해서 다음 씬에서도 가져가도록!
        PlayerPrefs.SetFloat("이동시간", totalSeconds);
    }
}