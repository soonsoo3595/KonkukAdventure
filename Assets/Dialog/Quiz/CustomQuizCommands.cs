using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomQuizCommands : MonoBehaviour
{
    [SerializeField] List<QuizData> quizDataList;

    private void Start()
    {
        quizDataList = DataMgr.Dialogue.quiz;
        this.gameObject.SetActive(false);
    }


}
