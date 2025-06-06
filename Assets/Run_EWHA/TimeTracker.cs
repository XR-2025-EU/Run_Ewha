using System.Diagnostics;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private Stopwatch stopwatch;
    public TMP_Text timeText;

    private bool isTracking = false;

    // ��ư ������Ʈ ���� ���� �߰�
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

    // ��ư Ŭ�� �� ȣ��: stopwatch ���� + ��ư �����
    public void StartTimer()
    {
        stopwatch.Reset();
        stopwatch.Start();
        isTracking = true;

        // ��ư�� ��Ȱ��ȭ�ؼ� ������� ��
        if (startButton != null)
        {
            startButton.SetActive(false);
        }
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
            timeText.text = string.Format("{0:D2}m {1:D2}s", minutes, seconds);
        }

        PlayerPrefs.SetFloat("�̵��ð�", totalSeconds);
    }
}