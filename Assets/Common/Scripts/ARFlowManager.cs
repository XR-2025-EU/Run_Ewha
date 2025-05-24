using UnityEngine;
using TMPro;

public class ARFlowManager : MonoBehaviour
{
    public TMP_Text speechText;

    private int index = 0;

    private string[] messages = {
        "포스코관 지하 1층 엘리베이터를 찾아주세요!",
        "엘리베이터에서 3층으로 올라가세요!",
        "공학A 강의실 앞에 도착하였습니다!"
    };

    public void OnARButtonClicked()
    {
        if (index < messages.Length - 1)
            index++;
        speechText.text = messages[index];
    }
}