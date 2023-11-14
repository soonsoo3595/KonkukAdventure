using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Cinemachine;

public class NpcTrigger : MonoBehaviour
{
    [SerializeField] DialogueRunner storyDialogu;

    [Header("NPC List")]
    [SerializeField] public CinemachineVirtualCamera _guide_Camera;
    [SerializeField] public CinemachineVirtualCamera _student_1_Camera;

    private CameraSwitcher _cameraSwitcher;
    private CinemachineVirtualCamera _now_Camera;
    private Popup popup;

    private void Awake()
    {
        Portal.NpcIn += NpcIn;
        Portal.NpcOut += NpcOut;
    }

    private void Start()
    {
        _cameraSwitcher = CameraSwitcher.cameraSwitcher;
    }

    void NpcIn(string Name)
    {
        storyDialogu.StartDialogue(Name);
        switch (Name)
        {
            case "Guide":
                _cameraSwitcher.SwitchPrioroty(_guide_Camera);
                _now_Camera = _guide_Camera;
                break;
            case "Student1":
                _cameraSwitcher.SwitchPrioroty(_student_1_Camera);
                _now_Camera = _student_1_Camera;
                break;
        }
    }

    void NpcOut(string Name)
    {
        if (_cameraSwitcher.isPlayerCamera != true)
        {
            _cameraSwitcher.SwitchPrioroty(_now_Camera);
        }
    }
}
