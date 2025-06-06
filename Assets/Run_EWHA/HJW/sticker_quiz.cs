using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticker_quiz : MonoBehaviour
{
    public GameObject stickerObject;

    void Start()
    {
        stickerObject.SetActive(false);
        EvaluateConditions();
    }

    public void EvaluateConditions()
    {
        int quiz1 = PlayerPrefs.GetInt("Quiz1Correct");
        int quiz2 = PlayerPrefs.GetInt("Quiz2Correct");

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
