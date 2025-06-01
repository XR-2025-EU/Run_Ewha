using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TipController : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public Button nextButton;

    public int currentIndex = 0;

    public readonly string[] messages = new string[]
    {
        "포스코관에서 종합과학관으로 가는 통로는 포스코관 4층에 있다.",
        "학관의 출구는 1층과 짝수층에 있다.",
        "공학관의 공도의 이름은 \"창의학습공간\" 이다.",
        "공학A와 공학B 사이를 이동할 때 지상 3층으로 가면 카드 키가 필요하다.",
        "공학A(Asan): 아산공학관, 공학B(Brand New): 신공학관",
        "공대 강당은 아산공학관 지하 1층에 있다.",
        "신공학관 지하 2층에는 샤워실이 있다.",
        "외부인은 ECC는 지하 4층까지만 출입할 수 있다.",
        "ECC 지하4층에는 영화관이 있다.",
        "셔틀을 타고 공학관으로 갈 땐 공대삼거리에서 하차한다.",
        "저녁 7시 이후로는 공대에서 셔틀 하차를 할 수 없다.",
        "공대도서관의 열람실(창의학습공간)은 24시간이다.",
        "공대 쪽문은 학생증으로 24시간 열고 닫을 수 있다.",
        "생활관에서 포관으로 가려면 2층의 출입문을 이용한다.",
        "ECC는 밤 12시에 문이 잠긴다.",
        "시험기간엔 중앙도서관을 24시간 이용가능하지만, 24시~익일 5시까지는 출입하지 못한다."
    };

    public void Start()
    {
        nextButton.onClick.AddListener(ShowNextMessage);
        infoText.text = messages[currentIndex];
    }

    public void ShowNextMessage()
    {
        currentIndex = (currentIndex + 1) % messages.Length;
        Debug.Log($"현재 인덱스: {currentIndex}, 메시지: {messages[currentIndex]}");
        infoText.text = messages[currentIndex];
    }
}
