using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryPopUpController : MonoBehaviour
{

    [SerializeField] TMP_Text alertName;
    [SerializeField] TMP_Text alertContext;
    [SerializeField] TMP_Text alertText;

    private Popup _popup;

    private bool _isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        _popup = GetComponent<Popup>();
        FirstPage();
    }

    void FirstPage()
    {
        alertName.text = "어서오세요!";
        alertContext.text = "건국대학교에 오신것을 환영합니다!";
        alertText.text = "\n환영합니다! 당신이 건국대학교에 오기만을 기다렸어요!\n당신은 앞으로 이곳에서 8학기를 보내게 될겁니다!";
    }

    public void SecondPage()
    {
        _isFirst = false;
        alertName.text = "어서오세요!";
        alertContext.text = "무엇을 해야할지 막막하다구요?";
        alertText.text = "\n걱정마세요! 그런 당신을 도와줄 학생회에서 나온 가이드 친구가 있으니까요!\n\n다음 버튼을 누르시고 앞에 있는 가이드에게 가까이 가보세요!";
    }

    public void GoToGuide()
    {
        if (!_isFirst)
        {
            PopupMgr.instance.ClosePopup(_popup);
        }
    }
}
