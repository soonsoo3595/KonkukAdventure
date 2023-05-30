using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandManager : MonoBehaviour
{
    DialogueRunner dialogueRunner;

    int index;

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
        Portal.SetDialogue += SetDialogue;
    }

    private void Start()
    {

    }

    //포탈 번호에 따른 퀴즈 진입
    void SetDialogue(int num)
    {
        switch (num)
        {
            case 32:
                index = 0;
                if (!DataMgr.Dialogue.quiz[index].isEnter)
                {
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 33:
                index = 1;
                if (!DataMgr.Dialogue.quiz[index].isEnter)
                {
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                Debug.Log("이미 본 퀴즈입니다.");
                break;
            case 34:
                index = 2;
                if (!DataMgr.Dialogue.quiz[index].isEnter)
                {
                    dialogueRunner.StartDialogue(num.ToString());
                    break;
                }
                Debug.Log("이미 본 퀴즈입니다.");
                break;
        }
    }

    public void QuizEnd()
    {
        GameManager.instance.exitUI();
        DataMgr.Dialogue.quiz[index].isEnter = true;
    }
}
