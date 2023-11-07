using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StoryCommendsManager : MonoBehaviour
{
    public delegate void DialogueEnd();
    public static event DialogueEnd DialogueEndCommand;

    public delegate void GetStoryState();
    public static event GetStoryState GetState;

    public delegate void SetStoryState();
    public static event GetStoryState SetState;

    private DialogueRunner dialogueRunner;

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
    }
    private void Start()
    {
        //커맨드 등록
        dialogueRunner.AddCommandHandler("End", DialogueEndCommand);
    }
}
