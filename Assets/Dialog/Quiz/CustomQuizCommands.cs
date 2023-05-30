using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomQuizCommands : MonoBehaviour
{
    [SerializeField] List<QuizData> quizDataList;

    private void Awake()
    {
        YarnCommandManager.SetQuiz += SetQuiz;
    }
    private void Start()
    {
        quizDataList = DataMgr.quizs.data;
    }

    public void SetQuiz(string tag)
    {
        switch (tag)
        {
            case "question": Debug.Log(quizDataList[0].question);
                break;
                //case "question": return quizDataList[0].question;
                //case "option_1": return quizDataList[0].options[0];
                //case "option_2": return quizDataList[0].options[1];
                //case "option_3": return quizDataList[0].options[2];
                //case "option_4": return quizDataList[0].options[3];
        }
        //return "아무런 데이터 저장되지 않았습니다.";
    }
}
