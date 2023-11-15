using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandManager : MonoBehaviour
{
    private int ID;
    //진입한 포탈 번호 받는 변수
    private int portalNum;

    [SerializeField] DialogueRunner StoryRunner;
    private Popup popup;

    private void Awake()
    {
        Portal.SetDialogue += SetDialogue;
        popup = GetComponent<Popup>();

        #region Yarn 커맨드 등록
        CustomQuizCommands.QuizCorrectCommand += QuizCorrect;
        CustomQuizCommands.DialogueEndCommand += DialogueEnd;
        StoryCommendsManager.DialogueEndCommand += DialogueEnd;
        #endregion
    }

    #region 포탈 번호에 따른 이벤트 진입
    void SetDialogue(int num)
    {
        portalNum = num;
        StoryRunner.Stop();

        switch (num)
        {
            //퀴즈 진입
            case 32:
                ID = 0;
                if (!DataMgr.Dialogue.quiz[ID].isEnter)
                {
                    GameManager.instance.enteringUI();
                    StoryRunner.StartDialogue(num.ToString());
                    break;
                }
                StoryRunner.StartDialogue("0");
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 33:
                ID = 1;
                if (!DataMgr.Dialogue.quiz[ID].isEnter)
                {
                    GameManager.instance.enteringUI();
                    StoryRunner.StartDialogue(num.ToString());
                    break;
                }
                StoryRunner.Stop();
                StoryRunner.StartDialogue("0");
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 34:
                ID = 2;
                if (!DataMgr.Dialogue.quiz[ID].isEnter)
                {
                    GameManager.instance.enteringUI();
                    StoryRunner.StartDialogue(num.ToString());
                    break;
                }
                StoryRunner.Stop();
                StoryRunner.StartDialogue("0");
                Debug.Log("이미 본 퀴즈입니다.");
                break;
        }
    }
    #endregion

    //퀴즈 정답, 평점 상승
    private void QuizCorrect()
    {
        DataMgr.Player.scoreReserve += DataMgr.Dialogue.quiz[ID].reward;
    }

    //다이얼로그 종료
    private void DialogueEnd()
    {
        switch (portalNum)
        {
            case 32:
            case 33:
            case 34:
                DataMgr.Dialogue.quiz[ID].isEnter = true;
                Debug.Log(DataMgr.Dialogue.quiz[ID].isEnter);
                break;
        }
        StoryRunner.Stop();
        PopupMgr.instance.ClosePopup(popup);
    }

    private void Checked()
    {
        if (!StoryRunner.startNode.Equals("0"))
        {
            StoryRunner.StartDialogue("0");
        }
        StoryRunner.Stop();
        StoryRunner.StartDialogue("0");
    }
}