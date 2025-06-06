using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stiker_time : MonoBehaviour
{
    public GameObject stickerObject;

    void Start()
    {
        stickerObject.SetActive(false);
        EvaluateConditions();
    }

    public void EvaluateConditions()
    {
        float totalSeconds = PlayerPrefs.GetFloat("이동시간");
        int quiz1 = PlayerPrefs.GetInt("Quiz1Correct");
        int quiz2 = PlayerPrefs.GetInt("Quiz2Correct");

        if (totalSeconds <= 900 && quiz1 == 1 && quiz2 == 1)
        {
            stickerObject.SetActive(true);
        }
        else
        {
            stickerObject.SetActive(false);
        }
    }
}
