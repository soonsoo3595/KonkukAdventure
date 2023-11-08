using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandManager : MonoBehaviour
{
    private int ID;
    //진입한 포탈 번호 받는 변수
    private int portalNum;

    private DialogueRunner dialogueRunner;
    private Popup popup;

    private void Awake()
    {
        Portal.SetDialogue += SetDialogue;
        popup = GetComponent<Popup>();
        dialogueRunner = GetComponent<DialogueRunner>();

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
        dialogueRunner.Stop();

        switch (num)
        {
            //퀴즈 진입
            case 32:
                ID = 0;
                if (!DataMgr.Dialogue.quiz[ID].isEnter)
                {
                    GameManager.instance.enteringUI();
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                dialogueRunner.StartDialogue("0");
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 33:
                ID = 1;
                if (!DataMgr.Dialogue.quiz[ID].isEnter)
                {
                    GameManager.instance.enteringUI();
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                dialogueRunner.Stop();
                dialogueRunner.StartDialogue("0");
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 34:
                ID = 2;
                if (!DataMgr.Dialogue.quiz[ID].isEnter)
                {
                    GameManager.instance.enteringUI();
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                dialogueRunner.Stop();
                dialogueRunner.StartDialogue("0");
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
        PopupMgr.instance.ClosePopup(popup);
    }

    private void Checked()
    {
        if (!dialogueRunner.startNode.Equals("0"))
        {
            dialogueRunner.StartDialogue("0");
        }
        dialogueRunner.Stop();
        dialogueRunner.StartDialogue("0");
    }
}