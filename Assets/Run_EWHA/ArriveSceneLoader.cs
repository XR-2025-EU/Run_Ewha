using UnityEngine;
using UnityEngine.SceneManagement;

public class ArriveSceneLoader : MonoBehaviour
{
    public TimeTracker timeTracker; // Inspector���� ������ ����!

    // ���� �Լ�: AR �ν� or ��ư Ŭ��
    public void GoToArriveScene()
    {
        if (timeTracker != null)
        {
            timeTracker.StopTimer(); // �ð� ���� + ����
        }

        // arrive_scene���� �̵�
        SceneManager.LoadScene("arrive_scene");
    }
}