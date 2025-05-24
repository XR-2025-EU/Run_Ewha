using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationUI : MonoBehaviour
{
    public ARFlowManager arFlow;

    public void OnARButtonClicked()
    {
        if (arFlow != null)
            arFlow.OnARButtonClicked();
    }

    public void OnReplayButtonClicked()
    {
        SceneManager.LoadScene("RouteScene");
    }
}