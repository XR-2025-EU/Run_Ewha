using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanelECC;  // Panel 전체
    public GameObject popupPanelPosco;
    public GameObject popupPanelSH;
    private bool isPop = false;

    void Start()
    {
        popupPanelECC.SetActive(false);
        popupPanelPosco.SetActive(false);
        popupPanelSH.SetActive(false);
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

        else if (Select_Timetable.Instance.selectedOption == 3)
        {
            if (!isPop)
            {
                popupPanelSH.SetActive(true);
                isPop = true;
            }
            else
            {
                popupPanelSH.SetActive(false);
                isPop = false;
            }

        }
    }
}