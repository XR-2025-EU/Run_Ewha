using UnityEngine;
using UnityEngine.SceneManagement;

public class ARImageRecognition : MonoBehaviour
{
    // AR ī�޶󿡼� ��� �ν� �� ȣ��Ǵ� �Լ�
    public void OnTargetFound()
    {
        Debug.Log("��� �νĵ�!");

        // �ҿ�ð� ���� ����
        FindObjectOfType<TimeTracker>().StopTimer();

        // �ʿ��� ��� �� ���� �� �ڵ����� �Ѿ��
        SceneManager.LoadScene("�������̸�");
    }
}