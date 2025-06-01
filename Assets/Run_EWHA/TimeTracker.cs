using System.Diagnostics;   // Stopwatch ���
using UnityEngine;
using TMPro;                 // TextMeshPro �ؽ�Ʈ�� ���� �ʿ�

public class TimeTracker : MonoBehaviour
{
    private Stopwatch stopwatch;       // �ҿ�ð��� ��� Stopwatch
    public TMP_Text timeText;          // UI�� �ҿ�ð� ǥ���� TMP_Text

    private bool isTracking = false;   // �ǽð� ���� �� ����

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
                timeText.text = string.Format("���� �ҿ� �ð�: {0:D2}�� {1:D2}��", minutes, seconds);
            }
        }
    }

    // �̵� ����
    public void StartTimer()
    {
        stopwatch.Reset();     // ���� ��� �ʱ�ȭ
        stopwatch.Start();     // ���� ���� ����
        isTracking = true;     // �ǽð� ���� ON
        UnityEngine.Debug.Log("�̵� ����!");
    }

    // �̵� ����
    public void StopTimer()
    {
        stopwatch.Stop();      // ���� ����
        isTracking = false;    // �ǽð� ���� OFF

        int totalSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000f);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        UnityEngine.Debug.Log("�̵��ð�: " + minutes + "�� " + seconds + "��");

        if (timeText != null)
        {
            timeText.text = string.Format("���� �ҿ� �ð�: {0:D2}�� {1:D2}��", minutes, seconds);
        }

        PlayerPrefs.SetFloat("�̵��ð�", stopwatch.ElapsedMilliseconds / 1000f);
    }
}