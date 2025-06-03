using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip_Controller_Image : MonoBehaviour
{
    public Image tipImage;
    public Button nextButton;

    private List<Sprite> tipSprites = new List<Sprite>();
    private int currentIndex = 0;

    void Start()
    {
        LoadTipImages();
        if (tipSprites.Count > 0)
        {
            tipImage.sprite = tipSprites[currentIndex];
        }

        nextButton.onClick.AddListener(ShowNextImage);
    }

    void LoadTipImages()
    {
        // Resources/Tips 폴더에 있는 모든 이미지 불러오기
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Tips_Images");
        tipSprites.AddRange(loadedSprites);
        Debug.Log($"불러온 팁 이미지 수: {tipSprites.Count}");
    }

    void ShowNextImage()
    {
        if (tipSprites.Count == 0) return;

        currentIndex = (currentIndex + 1) % tipSprites.Count;
        tipImage.sprite = tipSprites[currentIndex];
        Debug.Log($"현재 인덱스: {currentIndex}");
    }
}