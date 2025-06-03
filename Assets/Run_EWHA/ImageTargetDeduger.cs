using UnityEngine;
using Vuforia;

public class ImageTargetDeduger : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
            Debug.Log($"[DEBUG] '{gameObject.name}'에 ObserverBehaviour 연결됨");
        }
        else
        {
            Debug.LogError("[DEBUG] ObserverBehaviour를 찾을 수 없습니다!");
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        Debug.Log($"[DEBUG] Target: {behaviour.TargetName}, Status: {targetStatus.Status}, StatusInfo: {targetStatus.StatusInfo}");

        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            Debug.Log($"[DEBUG] '{behaviour.TargetName}' 인식됨 ✅");
        }
        else
        {
            Debug.Log($"[DEBUG] '{behaviour.TargetName}' 인식 안됨 ❌");
        }
    }
}
