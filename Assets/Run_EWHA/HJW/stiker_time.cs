

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stiker_time : MonoBehaviour
{
    private GameObject stickerObject;

    void Start()
    {
        // 씬 내에서 이름이 "Sticker_time"인 오브젝트를 찾음
        stickerObject = GameObject.Find("Sticker_time");

        if (stickerObject == null)
        {
            Debug.LogWarning("[stiker_time] 'Sticker_time'라는 이름의 오브젝트를 찾을 수 없습니다.");
            return;
        }

        stickerObject.SetActive(false);
        EvaluateConditions();
    }

    public void EvaluateConditions()
    {
        // 문자열 키에 깨진 문자("�̵��ð�")가 있음 → 한글로 저장했던 값은 깨질 수 있음
        // 해결: 영어로 된 키 이름으로 바꾸는 걸 추천 ("MovingTime" 등)

        float totalSeconds = PlayerPrefs.GetFloat("�̵��ð�");
        int quiz1 = PlayerPrefs.GetInt("Quiz1Correct");
        int quiz2 = PlayerPrefs.GetInt("Quiz2Correct");

        if (stickerObject == null) return;

        if (totalSeconds <= 900)
        {
            stickerObject.SetActive(true);
        }
        else
        {
            stickerObject.SetActive(false);
        }
    }
}
