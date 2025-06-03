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

        // ���� �ҿ� �ð��� UI�� ǥ������ �ʰ�, �׳� PlayerPrefs������ ����� �� ����
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
                timeText.text = string.Format("���� �ҿ� �ð�: {0:D2}�� {1:D2}��", minutes, seconds);
            }
        }
    }

    // ��ư Ŭ�� �� ȣ��: stopwatch ����
    public void StartTimer()
    {
        stopwatch.Reset();
        stopwatch.Start();
        isTracking = true;
    }

    // AR �νĵǸ� �ڵ����� ȣ��: stopwatch ���� + ��� ����
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
            timeText.text = string.Format("���� �ҿ� �ð�: {0:D2}�� {1:D2}��", minutes, seconds);
        }

        PlayerPrefs.SetFloat("�̵��ð�", totalSeconds);
    }
}