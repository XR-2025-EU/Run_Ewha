using UnityEngine;
using TMPro;

public class NavigationSceneUI : MonoBehaviour
{
    public TextMeshProUGUI currentPointText;
    public TextMeshProUGUI nextPointText;

    private int pointIndex = 0;
    private string[] points = {
        "ECC 정문", "포스코관 입구", "아산공학관 앞", "엘텍로비", "공학관 도착!"
    };

    public void OnNextClicked()
    {
        pointIndex = Mathf.Min(pointIndex + 1, points.Length - 1);
        currentPointText.text = "현재 위치: " + points[pointIndex];
        nextPointText.text = (pointIndex < points.Length - 1)
            ? "다음 지점: " + points[pointIndex + 1]
            : "도착했습니다!";
    }

    public void OnReplayRouteClicked()
    {
        pointIndex = 0;
        currentPointText.text = "현재 위치: " + points[pointIndex];
        nextPointText.text = "다음 지점: " + points[pointIndex + 1];
    }
}