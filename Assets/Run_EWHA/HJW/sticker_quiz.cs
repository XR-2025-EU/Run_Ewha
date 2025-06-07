using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticker_quiz : MonoBehaviour
{
    private GameObject stickerObject;

    void Start()
    {
        // 씬 내에서 이름이 "Sticker_quiz"인 오브젝트를 찾음
        stickerObject = GameObject.Find("Sticker_quiz");

        if (stickerObject == null)
        {
            Debug.LogWarning("[sticker_quiz] 'Sticker_quiz'라는 이름의 오브젝트를 찾을 수 없습니다.");
            return;
        }

        stickerObject.SetActive(false);
        EvaluateConditions();
    }

    public void EvaluateConditions()
    {
        int quiz1 = PlayerPrefs.GetInt("Quiz1Correct");
        int quiz2 = PlayerPrefs.GetInt("Quiz2Correct");

        if (stickerObject == null) return;
        
        if (quiz1 == 1 && quiz2 == 1)
        {
            stickerObject.SetActive(true);
        }
        else
        {
            stickerObject.SetActive(false);
        }
    }
}
