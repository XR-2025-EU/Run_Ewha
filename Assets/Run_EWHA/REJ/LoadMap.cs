using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    public GameObject popupPanel;
    public void SelectedSH()
    {
        popupPanel.SetActive(true);
    }

    public void returnTimeTable()
    {
        SceneManager.LoadScene("REJ_TimeTable");
    }
    public void LoadNavigate()
    {
        SceneManager.LoadScene("NavigationScene");  // ECC 선택 → Scene1
    }
}
