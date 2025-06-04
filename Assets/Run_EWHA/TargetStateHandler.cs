using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using TMPro;

public class TargetStateHandler : MonoBehaviour
{
    public GameObject[] arrowUIImages;
    public int myTargetIndex;
    public GameManager gameManager;
    public MSJ_PopupManager popupManager;

    public TextMeshProUGUI instructionText; // UI Text 오브젝트
    public string[] instructionMessages;    // index별 문구 리스트

    public string nextSceneName;

    private ObserverBehaviour observer;
    private bool hasActivated = false;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        foreach (var arrow in arrowUIImages)
        {
            if (arrow != null)
                arrow.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (observer)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if ((status.Status == Status.TRACKED ||
             status.Status == Status.EXTENDED_TRACKED ||
             status.Status == Status.LIMITED) &&
            gameManager.currentState == myTargetIndex &&
            !hasActivated)
        {
            hasActivated = true;

            // 여기서 타이머 멈추고 소요 시간 저장
            var timeTracker = FindObjectOfType<TimeTracker>();
            if (timeTracker != null)
            {
                timeTracker.StopTimer();
                Debug.Log("타이머 정지 및 소요 시간 저장 완료!");
            }
            else
            {
                Debug.LogWarning("TimeTracker를 찾을 수 없습니다!");
            }

            // 화살표 UI 업데이트
            for (int i = 0; i < arrowUIImages.Length; i++)
            {
                if (arrowUIImages[i] != null)
                    arrowUIImages[i].SetActive(i == myTargetIndex);
            }

            // 텍스트 안내 업데이트
            if (instructionText != null && instructionMessages.Length > myTargetIndex)
            {
                instructionText.text = instructionMessages[myTargetIndex];
            }

            // 팝업 매니저에서 이미지 업데이트
            if (popupManager != null && myTargetIndex + 1 < popupManager.imageList.Length)
            {
                popupManager.ShowImageByIndex(myTargetIndex + 1);
            }

            // 단계 진행
            gameManager.AdvanceState();

            // 다음 씬으로 전환
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
