using UnityEngine;

public class ARImageRecognition : MonoBehaviour
{
    // 예제: AR카메라에서 대상 인식 시 호출되는 함수
    public void OnTargetFound()
    {
        UnityEngine.Debug.Log("대상 인식됨!");

        // 소요시간 측정 종료
        FindObjectOfType<TimeTracker>().StopTimer();

        // 필요한 경우 → 다음 씬 자동으로 넘어가기
        UnityEngine.SceneManagement.SceneManager.LoadScene("다음씬이름");
    }
}