using UnityEngine;
using TMPro;

public class NavigationSceneUI : MonoBehaviour
{
    public TextMeshProUGUI currentPointText;
    public TextMeshProUGUI nextPointText;

    private int pointIndex = 0;
    private string[] points = {
        "ECC ����", "�����ڰ� �Ա�", "�ƻ���а� ��", "���طκ�", "���а� ����!"
    };

    public void OnNextClicked()
    {
        pointIndex = Mathf.Min(pointIndex + 1, points.Length - 1);
        currentPointText.text = "���� ��ġ: " + points[pointIndex];
        nextPointText.text = (pointIndex < points.Length - 1)
            ? "���� ����: " + points[pointIndex + 1]
            : "�����߽��ϴ�!";
    }

    public void OnReplayRouteClicked()
    {
        pointIndex = 0;
        currentPointText.text = "���� ��ġ: " + points[pointIndex];
        nextPointText.text = "���� ����: " + points[pointIndex + 1];
    }
}