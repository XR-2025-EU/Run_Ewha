using UnityEngine;

public class WelcomingSceneManager : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("이동시간");
        Debug.Log("앱 시작 시 '이동시간' 초기화 완료!");
    }
}