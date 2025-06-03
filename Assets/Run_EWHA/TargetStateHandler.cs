using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using TMPro; // ✅ 추가

public class TargetStateHandler : MonoBehaviour
{
    public GameObject[] arrowUIImages;
    public int myTargetIndex;
    public GameManager gameManager;
    public MSJ_PopupManager popupManager;

    public TextMeshProUGUI instructionText;         // ✅ UI Text 오브젝트
    public string[] instructionMessages;            // ✅ index별 문구 리스트

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

            for (int i = 0; i < arrowUIImages.Length; i++)
            {
                if (arrowUIImages[i] != null)
                    arrowUIImages[i].SetActive(i == myTargetIndex);
            }

            // ✅ 텍스트 변경
            if (instructionText != null && instructionMessages.Length > myTargetIndex)
            {
                instructionText.text = instructionMessages[myTargetIndex];
            }

            if (popupManager != null && myTargetIndex + 1 < popupManager.imageList.Length)
            {
                popupManager.ShowImageByIndex(myTargetIndex + 1);
            }

            gameManager.AdvanceState();

            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
