using UnityEngine;

public class ARImageRecognition : MonoBehaviour
{
    // ����: ARī�޶󿡼� ��� �ν� �� ȣ��Ǵ� �Լ�
    public void OnTargetFound()
    {
        UnityEngine.Debug.Log("��� �νĵ�!");

        // �ҿ�ð� ���� ����
        FindObjectOfType<TimeTracker>().StopTimer();

        // �ʿ��� ��� �� ���� �� �ڵ����� �Ѿ��
        UnityEngine.SceneManagement.SceneManager.LoadScene("�������̸�");
    }
}