using UnityEngine;
using TMPro;

public class ARFlowManager : MonoBehaviour
{
    public TMP_Text speechText;

    private int index = 0;

    private string[] messages = {
        "�����ڰ� ���� 1�� ���������͸� ã���ּ���!",
        "���������Ϳ��� 3������ �ö󰡼���!",
        "����A ���ǽ� �տ� �����Ͽ����ϴ�!"
    };

    public void OnARButtonClicked()
    {
        if (index < messages.Length - 1)
            index++;
        speechText.text = messages[index];
    }
}