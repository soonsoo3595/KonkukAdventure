using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StoryManager : MonoBehaviour
{
    public static StoryManager storyManager;

    private Popup popup;
    [SerializeField] DialogueRunner dialogueRunner;

    [SerializeField] RectTransform dialogue;
    [SerializeField] RectTransform playerInfo;
    [SerializeField] GameObject dialogNextBtn;

    private VariableStorageBehaviour _variableStorage;
    [SerializeField]  private float _storyState = -1;

    // Start is called before the first frame update
    void Awake()
    {
        storyManager = this;

        SetCommends();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            popup = PopupMgr.instance.dialoguePopup;
            PopupMgr.instance.OpenPopup(popup);
            dialogueRunner.StartDialogue("GameStart");
            _variableStorage = dialogueRunner.VariableStorage;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            _storyState += 1;
            SetStoryState( _storyState);
        }
        StoryCheck();
    }

    #region 대화 명령어
    void SetCommends()
    {
        dialogueRunner.AddCommandHandler<int>(
                    "Get_Story",     // the name of the command
                    GetStoryState // the method to run
                );
        dialogueRunner.AddCommandHandler<int>(
                    "Disable_Button",
                    DisableNextBnt
            );
        dialogueRunner.AddCommandHandler<int>(
                   "Enable_Button",
                   EnableNextBtn
           );
    }

    void GetStoryState(int TrashNum)
    {
        _storyState = TrashNum;
        //_variableStorage.TryGetValue("$Story_State", out _storyState);
        Debug.Log($"현재 스토리는 {_storyState} 단계입니다");
    }

    void SetStoryState(float variable)
    {
        _variableStorage.SetValue("$Story_State", variable);
    }

    void DisableNextBnt(int num)
    {
        Debug.Log("버튼 없어짐");
        LineView.lineView.continueButton = null;
        dialogNextBtn.SetActive(false);
    }

    void EnableNextBtn(int num)
    {
        dialogNextBtn.SetActive(true);
        LineView.lineView.continueButton = dialogNextBtn;
    }
    #endregion

    void StoryCheck()
    {
        //상태창 튜토리얼
        if(_storyState == 1)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SetStoryState(2);
                Debug.Log("2단계 튜토리얼 시작");
                PopupMgr.instance.ClosePopup(popup);
                PopupMgr.instance.OpenPopup(popup);
                playerInfo.anchoredPosition = new Vector3(0, 185, 0);
                dialogue.anchoredPosition = new Vector3(0, -365, 0);
                LineView.lineView.OnContinueClicked();
            }
        }
    }

    public void StoryState_2()
    {
        if(_storyState == 2)
        {
            SetStoryState(3);
            LineView.lineView.OnContinueClicked();
        }
    }
}
