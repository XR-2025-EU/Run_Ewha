using UnityEngine;

public class WelcomingSceneManager : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("�̵��ð�");
        Debug.Log("�� ���� �� '�̵��ð�' �ʱ�ȭ �Ϸ�!");
    }
}