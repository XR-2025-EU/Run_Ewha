using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanelECC;  // Panel 전체
    public GameObject popupPanelPosco;
    private bool isPop = false;

    void Start()
    {
        popupPanelECC.SetActive(false);
    }

    public void ShowPopup()
    {
        if (Select_Timetable.Instance.selectedOption == 1)
        {
            if (!isPop)
            {
                popupPanelECC.SetActive(true);
                isPop = true;
            }
            else
            {
                popupPanelECC.SetActive(false);
                isPop = false;
            }

        }
        else if (Select_Timetable.Instance.selectedOption == 2)
        {
            if (!isPop)
            {
                popupPanelPosco.SetActive(true);
                isPop = true;
            }
            else
            {
                popupPanelPosco.SetActive(false);
                isPop = false;
            }
        }
    }
}