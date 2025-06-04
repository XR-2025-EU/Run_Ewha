using UnityEngine;
using UnityEngine.SceneManagement;

public class ArriveSceneLoader : MonoBehaviour
{
    public TimeTracker timeTracker; // Inspector에서 연결할 예정!

    // 공통 함수: AR 인식 or 버튼 클릭
    public void GoToArriveScene()
    {
        if (timeTracker != null)
        {
            timeTracker.StopTimer(); // 시간 정지 + 저장
        }

        // arrive_scene으로 이동
        SceneManager.LoadScene("arrive_scene");
    }
}