using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Select_Timetable : MonoBehaviour
{
    public TMP_Text text1;

    private int selectedOption = 0;  // 1: ECC, 2: 포스코

    public void SetToECC()
    {
        text1.text = "<b>ECC(캠)</b>";
        selectedOption = 1;
    }

    public void SetToPosco()
    {
        text1.text = "<b>포스코관(포)</b>";
        selectedOption = 2;
    }

    public void SetToSH()
    {
        text1.text = "<b>생활환경관(생활)</b>";
        selectedOption = 3;
    }

    public void OnNextButton()
    {
        if (selectedOption == 1)
        {
            SceneManager.LoadScene("REJ_MapFromECC");  // ECC 선택 → Scene1
        }
        else if (selectedOption == 2)
        {
            SceneManager.LoadScene("REJ_MapFromPosco");  // 포스코 선택 → Scene2
        }
        else if (selectedOption == 3)
        {
            SceneManager.LoadScene("REJ_MapFromSH");  // 생활환경 선택 → Scene3
        }
        else
        {
            Debug.Log("선택이 없습니다!");
        }
    }
}