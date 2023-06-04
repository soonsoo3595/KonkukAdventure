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

    private void Awake()
    {
        Portal.SetDialogue += SetDialogue;
        dialogueRunner = GetComponent<DialogueRunner>();

        #region Yarn 커맨드 등록
        CustomQuizCommands.quizCorrect += QuizCorrect;
        CustomQuizCommands.dialogueEnd += DialogueEnd;
        #endregion
    }

    #region 포탈 번호에 따른 이벤트 진입
    void SetDialogue(int num)
    {
        portalNum = num;

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
                Debug.Log("이미 본 퀴즈입니다.");
                break;
        }
    }
    #endregion

    //퀴즈 정답, 평점 상승
    private void QuizCorrect()
    {
        DataMgr.player.scoreReserve += DataMgr.Dialogue.quiz[ID].reward;
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
                transform.parent.gameObject.SetActive(false);
                break;
        }
        GameManager.instance.exitUI();
    }
}
