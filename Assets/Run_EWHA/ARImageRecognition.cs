using UnityEngine;
using UnityEngine.SceneManagement;

public class ARImageRecognition : MonoBehaviour
{
    // AR 카메라에서 대상 인식 시 호출되는 함수
    public void OnTargetFound()
    {
        Debug.Log("대상 인식됨!");

        // 소요시간 측정 종료
        FindObjectOfType<TimeTracker>().StopTimer();

        // 필요한 경우 → 다음 씬 자동으로 넘어가기
        SceneManager.LoadScene("다음씬이름");
    }
}