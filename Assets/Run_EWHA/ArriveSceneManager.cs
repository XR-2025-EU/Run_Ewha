using UnityEngine;
using TMPro;

public class ArriveSceneManager : MonoBehaviour
{
    public TMP_Text arriveTimeText; // Inspector���� ����

    void Start()
    {
        if (PlayerPrefs.HasKey("�̵��ð�"))
        {
            float totalSeconds = PlayerPrefs.GetFloat("�̵��ð�");
            int minutes = (int)totalSeconds / 60;
            int seconds = (int)totalSeconds % 60;

            arriveTimeText.text = $"�ҿ� �ð�: {minutes:D2}�� {seconds:D2}��";
            Debug.Log($"���� ������ ���� �ð�: {minutes:D2}�� {seconds:D2}��");
        }
        else
        {
            arriveTimeText.text = "�ҿ� �ð�: ���� ����";
            Debug.Log("����� �̵��ð��� �����ϴ�!");
        }
    }
}