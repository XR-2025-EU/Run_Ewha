using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentState = 0; // 0부터 시작

    [Header("Instruction Text Settings")]
    public TextMeshProUGUI instructionText;      // UI에 표시할 텍스트
    public string[] instructionMessages;         // 단계별 안내 메시지 배열

    void Start()
    {
        // 시작할 때 0번 메시지 표시
        if (instructionText != null && instructionMessages.Length > 0)
        {
            instructionText.text = instructionMessages[0];
        }
    }

    public void AdvanceState()
    {
        currentState++;
        Debug.Log("Now moving to state: " + currentState);
    }
}
