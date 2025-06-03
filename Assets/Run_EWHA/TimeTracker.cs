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

        // ���� ������ ���� �ҿ�ð� �ҷ�����
        if (PlayerPrefs.HasKey("�̵��ð�"))
        {
            float lastTime = PlayerPrefs.GetFloat("�̵��ð�");
            int totalSeconds = (int)lastTime;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (timeText != null)
            {
                timeText.text = string.Format("���� �ҿ� �ð�: {0:D2}�� {1:D2}��", minutes, seconds);
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
                timeText.text = string.Format("���� �ҿ� �ð�: {0:D2}�� {1:D2}��", minutes, seconds);
            }
        }
    }

    // ���� ��ư���� �� �Լ��� ȣ��
    public void StartTimer()
    {
        stopwatch.Reset();
        stopwatch.Start();
        isTracking = true;
        UnityEngine.Debug.Log("�̵� ����!");  // UnityEngine.Debug�� ���
    }

    // AR ī�޶󿡼� ��� �νĵǸ� �� �Լ� �ڵ� ȣ��!
    public void StopTimer()
    {
        if (!stopwatch.IsRunning) return;

        stopwatch.Stop();
        isTracking = false;

        float totalSeconds = stopwatch.ElapsedMilliseconds / 1000f;
        int minutes = (int)totalSeconds / 60;
        int seconds = (int)totalSeconds % 60;

        UnityEngine.Debug.Log("���� �ҿ�ð�: " + minutes + "�� " + seconds + "��");  // UnityEngine.Debug�� ���

        if (timeText != null)
        {
            timeText.text = string.Format("���� �ҿ� �ð�: {0:D2}�� {1:D2}��", minutes, seconds);
        }

        // PlayerPrefs�� �����ؼ� ���� �������� ����������!
        PlayerPrefs.SetFloat("�̵��ð�", totalSeconds);
    }
}