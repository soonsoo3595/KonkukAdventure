using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomQuizCommands : MonoBehaviour
{
    QuizDataList quizDataList;

    public void Awake()
    {
        quizDataList = DataMgr.quizs;
    }

    [YarnCommand("set_question")]
    public string SetQuestion()
    {
        return quizDataList.data[0].question;
    }

    [YarnCommand("set_option_1")]
    public string SetOptions1()
    {
        return quizDataList.data[0].options[0];
    }

    [YarnCommand("set_option_2")]
    public string SetOptions2()
    {
        return quizDataList.data[0].options[1];
    }

    [YarnCommand("set_option_3")]
    public string SetOptions3()
    {
        return quizDataList.data[0].options[2];
    }

    [YarnCommand("set_option_4")]
    public string SetOptions4()
    {
        return quizDataList.data[0].options[3];
    }
}
