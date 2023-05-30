using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandManager : MonoBehaviour
{
    public delegate void Quiz(string tag);
    public static event Quiz SetQuiz;

    DialogueRunner dialogueRunner;

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
    }

    private void Start()
    {
        dialogueRunner.AddCommandHandler("Quiz", SetQuiz);
    }
}
