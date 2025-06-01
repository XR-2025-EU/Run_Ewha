using UnityEngine;
using Vuforia;

public class TargetStateHandler : MonoBehaviour
{
    public GameObject arrowObject;
    public int myTargetIndex;
    public GameManager gameManager;

    private ObserverBehaviour observer;

    public MSJ_PopupManager popupManager;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (arrowObject != null)
            arrowObject.SetActive(false);
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
            gameManager.currentState == myTargetIndex)
        {
            if (arrowObject != null && !arrowObject.activeSelf)
            {
                arrowObject.SetActive(true);

                // 🎯 다음 인식 대상을 팝업으로 보여줌
                if (popupManager != null && myTargetIndex + 1 < popupManager.imageList.Length)
                {
                    popupManager.ShowImageByIndex(myTargetIndex + 1);
                }

                gameManager.AdvanceState();
            }
        }

    }
}
