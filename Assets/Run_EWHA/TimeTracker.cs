using System.Diagnostics; // Stopwatch 때문에 필요!
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private Stopwatch stopwatch;
    public TMP_Text timeText;

    private bool isTracking = false;

    // 버튼 오브젝트 연결
    public GameObject startButton;

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
                timeText.text = string.Format("{0:D2}m {1:D2}s", minutes, seconds);
            }
        }
    }

    // 버튼 클릭 시 호출: 타이머 시작 + 버튼 숨김
    public void StartTimer()
    {
        stopwatch.Reset();
        stopwatch.Start();
        isTracking = true;

        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        UnityEngine.Debug.Log("타이머 시작됨!");
    }

    // 마지막 단계에서 AR 인식되면 호출: 타이머 정지 + 시간 저장
    public void StopTimer()
    {
        if (!stopwatch.IsRunning) return;

        stopwatch.Stop();
        isTracking = false;

        float totalSeconds = stopwatch.ElapsedMilliseconds / 1000f;
        int minutes = (int)totalSeconds / 60;
        int seconds = (int)totalSeconds % 60;

        if (timeText != null)
        {
            timeText.text = string.Format("{0:D2}m {1:D2}s", minutes, seconds);
        }

        // 저장 키 수정 완료!
        PlayerPrefs.SetFloat("이동시간", totalSeconds);

        // UnityEngine.Debug로 명시!
        UnityEngine.Debug.Log($"타이머 종료! 저장된 소요 시간: {minutes:D2}m {seconds:D2}s");
    }
}