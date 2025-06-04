using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select_Timetable : MonoBehaviour
{
    public static Select_Timetable Instance;

    public TMP_Text text1;

    public int selectedOption = 0;  // 1: ECC, 2: 포스

    public Button ECC;
    public Button Posco;
    public Button SH;
    public Button nextButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 이 오브젝트를 다음 씬에서도 유지!
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 각 씬에서 버튼을 다시 찾아야 함
        ECC = GameObject.Find("ECC_Button")?.GetComponent<Button>();
        Posco = GameObject.Find("Posco_Button")?.GetComponent<Button>();
        SH = GameObject.Find("SH_Button")?.GetComponent<Button>();
        nextButton = GameObject.Find("Next_Button")?.GetComponent<Button>();
        text1 = GameObject.Find("Text_Selected")?.GetComponent<TMP_Text>();

        SetupButtons(); // ✅ 버튼 리스너 연결
    }

    void SetupButtons()
    {
        if (nextButton != null)
        {
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(OnNextButton);
        }

        if (ECC != null)
        {
            ECC.onClick.RemoveAllListeners();
            ECC.onClick.AddListener(SetToECC);
        }

        if (Posco != null)
        {
            Posco.onClick.RemoveAllListeners();
            Posco.onClick.AddListener(SetToPosco);
        }

        if (SH != null)
        {
            SH.onClick.RemoveAllListeners();
            SH.onClick.AddListener(SetToSH);
        }
    }

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