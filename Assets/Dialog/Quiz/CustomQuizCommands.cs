using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomQuizCommands : MonoBehaviour
{

    public delegate void QuizCorrect();
    public static event QuizCorrect quizCorrect;

    //다이얼로그 종료 델리게이트, 퀴즈 커맨드 안에 구현되어있어 빼고싶음
    public delegate void DialogueEnd();
    public static event DialogueEnd dialogueEnd;

    private DialogueRunner dialogueRunner;

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
    }
    private void Start()
    {
        //커맨드 등록
        dialogueRunner.AddCommandHandler("Correct", quizCorrect);
        dialogueRunner.AddCommandHandler("End", dialogueEnd);
    }
}
