using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSJ_PopupManager : MonoBehaviour
{
    public GameObject popupPanel;   // 팝업 패널 오브젝트
    public Image popupImage;        // 팝업에 표시될 이미지
    public Sprite[] imageList;      // 이미지 목록 (Inspector에서 설정)

    private int currentImageIndex = 0;   // 현재 이미지 인덱스
    private bool isPopupVisible = false; // 팝업 표시 여부

    // ✅ 최근 설정된 인덱스 기억
    private int lastShownIndex = 0;

    // 팝업을 켜고 끄는 함수
    public void TogglePopup()
    {
        isPopupVisible = !isPopupVisible;
        popupPanel.SetActive(isPopupVisible);

        if (isPopupVisible && imageList.Length > 0)
        {
            // 팝업을 열 때 마지막으로 지정된 이미지를 보여줌
            popupImage.sprite = imageList[lastShownIndex];
        }
    }

    // 다음 이미지로 전환하는 함수
    public void ShowNextImage()
    {
        if (imageList.Length == 0) return;

        currentImageIndex = (currentImageIndex + 1) % imageList.Length;
        popupImage.sprite = imageList[currentImageIndex];

        // ✅ currentIndex가 업데이트되었으므로 저장
        lastShownIndex = currentImageIndex;
    }
    
    public void ShowImageByIndex(int index)
    {
        if (imageList.Length == 0 || index >= imageList.Length) return;

        popupImage.sprite = imageList[index];
        popupPanel.SetActive(true); // 항상 켜줌

        // ✅ 기억해둠
        lastShownIndex = index;
    }
}
