using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stiker_time : MonoBehaviour
{
    public GameObject stickerObject;

    void Start()
    {
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
        float totalSeconds = PlayerPrefs.GetFloat("�̵��ð�");
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
