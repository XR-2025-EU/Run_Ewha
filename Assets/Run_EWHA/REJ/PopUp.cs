using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanelECC;  // Panel 전체
    public GameObject popupPanelPosco;

    public void ShowPopup(float duration = 2f)
    {
        if (Select_Timetable.Instance.selectedOption == 1) { 
            popupPanelECC.SetActive(true);
            Invoke("HidePopup", duration); // duration초 뒤에 사라지게
        }
        else if (Select_Timetable.Instance.selectedOption == 2) { 
            popupPanelPosco.SetActive(true);
            Invoke("HidePopup", duration); // duration초 뒤에 사라지게
        }
    }

    void HidePopup()
    {
        popupPanelECC.SetActive(false);
        popupPanelPosco.SetActive(false);
    }
}