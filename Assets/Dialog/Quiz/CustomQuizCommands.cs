using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomQuizCommands : MonoBehaviour
{
    private void Awake()
    {
        YarnCommandManager.quizCorrect += QuizCorrect;
        YarnCommandManager.quizEnd += QuizEnd;
    }

    private void QuizCorrect(int index)
    {
        DataMgr.player.scoreReserve += DataMgr.Dialogue.quiz[index].reward;
    }

    private void QuizEnd(int index)
    {
        DataMgr.Dialogue.quiz[index].isEnter = true;
        GameManager.instance.exitUI();

        Debug.Log(DataMgr.Dialogue.quiz[index].isEnter +" conform:"+ DataMgr.Dialogue.quiz[0].isEnter.ToString());
    }
}
