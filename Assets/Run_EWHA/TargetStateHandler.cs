using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using TMPro;

using UI_Image = UnityEngine.UI.Image;

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


    // ✅ 이모지 관련 필드 
    public Sprite[] emojiSprites;
    public UI_Image emojiImage;

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

        // 초기 이모지 설정 (첫 번째 이모지 또는 null)
        if (emojiImage != null)
        {
            emojiImage.gameObject.SetActive(true);  // 항상 보이게
            if (emojiSprites != null && emojiSprites.Length > 0)
            {
                emojiImage.sprite = emojiSprites[0]; // 초기 이모지를 첫 번째로 세팅
            }
            else
            {
                emojiImage.sprite = null; // 없으면 빈 이미지
            }
        }
    }

    private void OnDestroy()
    {
        if (observer)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    // 랜덤 이모지 선택 
    void ShowRandomEmoji()
{
    if (emojiSprites != null && emojiSprites.Length > 0 && emojiImage != null)
    {
        int rand = Random.Range(0, emojiSprites.Length);
        emojiImage.sprite = emojiSprites[rand];
        emojiImage.gameObject.SetActive(true);  // 혹시 비활성화 상태일 경우
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

            // 안내 이모지 변경
            ShowRandomEmoji();

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
