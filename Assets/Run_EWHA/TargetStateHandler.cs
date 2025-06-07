using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using TMPro;
using UI_Image = UnityEngine.UI.Image;

public class TargetStateHandler : MonoBehaviour
{
    public GameObject[] arrowUIImages;
    public int myTargetIndex;             // 각 타겟의 index (0~4)
    public int finalTargetIndex = 4;      // 마지막 단계 index (5번째 인식 = index 4)
    public GameManager gameManager;
    public MSJ_PopupManager popupManager;

    public TextMeshProUGUI instructionText;     // 단계별 안내문
    public string[] instructionMessages;        // 단계별 안내 메시지

    public string nextSceneName;                // 마지막 단계 이후 씬 이름

    private ObserverBehaviour observer;
    private bool hasActivated = false;

    public Sprite[] emojiSprites;
    public UI_Image emojiImage;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        // 화살표 UI 전부 비활성화
        foreach (var arrow in arrowUIImages)
        {
            if (arrow != null)
                arrow.SetActive(false);
        }

        // ✅ emojiSprites 자동 로딩
        emojiSprites = new Sprite[]
        {
            Resources.Load<Sprite>("Sprites/NPC"),
            Resources.Load<Sprite>("Sprites/NPC_2"),
            Resources.Load<Sprite>("Sprites/NPC_3")
        };

        // null 체크 및 경고
        for (int i = 0; i < emojiSprites.Length; i++)
        {
            if (emojiSprites[i] == null)
            {
                Debug.LogWarning($"❌ emojiSprites[{i}] 로드 실패! 경로를 확인하세요.");
            }
        }

        // 초기 이모지 설정
        if (emojiImage != null)
        {
            emojiImage.gameObject.SetActive(true);  // 항상 보이게
            if (emojiSprites != null && emojiSprites.Length > 0 && emojiSprites[0] != null)
            {
                emojiImage.sprite = emojiSprites[0];
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

    void ShowRandomEmoji()
    {
        Debug.Log("🎯 ShowRandomEmoji() 호출됨");

        if (emojiSprites == null)
        {
            Debug.LogWarning("⚠️ emojiSprites가 null입니다!");
            return;
        }

        if (emojiSprites.Length == 0)
        {
            Debug.LogWarning("⚠️ emojiSprites의 길이가 0입니다!");
            return;
        }

        if (emojiImage == null)
        {
            Debug.LogWarning("⚠️ emojiImage가 null입니다!");
            return;
        }

        int rand = Random.Range(0, emojiSprites.Length);
        Debug.Log($"🎲 랜덤 인덱스: {rand}");
        emojiImage.sprite = emojiSprites[rand];
        emojiImage.gameObject.SetActive(true);
        Debug.Log("✅ 이모지 이미지 변경 완료");
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

            // 마지막 단계에서만 타이머 멈춤 + 저장
            if (myTargetIndex == finalTargetIndex)
            {
                var timeTracker = FindObjectOfType<TimeTracker>();
                if (timeTracker != null)
                {
                    timeTracker.StopTimer();
                    Debug.Log("마지막 단계 (아산공학관)에서 타이머 멈춤!");
                }
                else
                {
                    Debug.LogWarning("TimeTracker를 찾을 수 없습니다!");
                }
            }

            ShowRandomEmoji();

            // 화살표 UI 갱신
            for (int i = 0; i < arrowUIImages.Length; i++)
            {
                if (arrowUIImages[i] != null)
                    arrowUIImages[i].SetActive(i == myTargetIndex);
            }

            // 안내문 갱신
            if (instructionText != null && instructionMessages.Length > myTargetIndex)
            {
                instructionText.text = instructionMessages[myTargetIndex];
            }

            // 팝업 이미지 갱신
            if (popupManager != null && myTargetIndex + 1 < popupManager.imageList.Length)
            {
                popupManager.ShowImageByIndex(myTargetIndex + 1);

                emojiImage.sprite = emojiSprites[(myTargetIndex+1) % 3];
            }

            // 단계 진행
            gameManager.AdvanceState();

            // 마지막 단계에서 다음 씬으로 이동
            if (myTargetIndex == finalTargetIndex && !string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}