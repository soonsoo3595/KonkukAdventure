using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandManager : MonoBehaviour
{
    public delegate void QuizCorrect(int num);
    public static event QuizCorrect quizCorrect;

    public delegate void QuizEnd(int num);
    public static event QuizEnd quizEnd;

    private DialogueRunner dialogueRunner;

    private int index;

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
        Portal.SetDialogue += SetDialogue;
    }
    private void Start()
    {
        dialogueRunner.AddCommandHandler("Correct", quizCorrect);
        dialogueRunner.AddCommandHandler("QuizEnd", quizEnd);
    }

    //포탈 번호에 따른 이벤트 진입
    void SetDialogue(int num)
    {
        switch (num)
        {
            //퀴즈 진입
            case 32:
                index = 0;
                if (!DataMgr.Dialogue.quiz[index].isEnter)
                {
                    GameManager.instance.enteringUI();
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 33:
                index = 1;
                if (!DataMgr.Dialogue.quiz[index].isEnter)
                {
                    GameManager.instance.enteringUI();
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 34:
                index = 2;
                if (!DataMgr.Dialogue.quiz[index].isEnter)
                {
                    GameManager.instance.enteringUI();
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                Debug.Log("이미 본 퀴즈입니다.");
                break;
        }
    }
}
