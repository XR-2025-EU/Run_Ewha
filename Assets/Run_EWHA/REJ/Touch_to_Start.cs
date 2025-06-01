using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch_to_Start : MonoBehaviour
{
    void Update()
    {
        // 마우스 클릭 또는 터치 입력 감지
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            // 터치일 경우, TouchPhase가 Began일 때만
            if (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        // 씬 이름으로 로드
        SceneManager.LoadScene("REJ_TimeTable");

        // 또는 빌드 인덱스로 로드
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}