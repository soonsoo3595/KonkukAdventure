using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Cinemachine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager storyManager;

    private Popup popup;
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] LineView lineView;

    [Header("UI List")]
    [SerializeField] RectTransform dialogue;
    [SerializeField] RectTransform playerInfo;
    [SerializeField] RectTransform PlaceInfo;
    [SerializeField] RectTransform StudyUI;

    [Header("Btn List")]
    [SerializeField] GameObject dialogNextBtn;
    [SerializeField] GameObject StoryStartBtn;
    private VariableStorageBehaviour _variableStorage;
    private CinemachineVirtualCamera _tempCamera;

    [Header("Story State")]
    [SerializeField]  public float storyState = -1;

    // Start is called before the first frame update
    void Awake()
    {
        storyManager = this;

        SetCommends();
    }

    // Update is called once per frame
    void Update()
    {
        StoryStart();
        StoryCheck();
    }

    public void StoryStart()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            popup = PopupMgr.instance.dialoguePopup;
            PopupMgr.instance.OpenPopup(popup);
            dialogueRunner.StartDialogue("GameStart");
            _variableStorage = dialogueRunner.VariableStorage;
            // StoryStartBtn.SetActive(false);
        }
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
        dialogueRunner.AddCommandHandler<int>(
                   "Get_New_Quest",
                   GetNewQuest
           );
        dialogueRunner.AddCommandHandler<int>(
                   "Navigate_Portal",
                   NavigatePortal
           );
        dialogueRunner.AddCommandHandler<int>(
                   "DisNavigate_Portal",
                   DisNavigatePortal
           );
        dialogueRunner.AddCommandHandler<int>(
                   "Camera_Out",
                   CameraOut
           );
        dialogueRunner.AddCommandHandler<int>(
                   "UI_Init",
                   UIInit
           );
        dialogueRunner.AddCommandHandler<int>(
           "Study_UI_Trans",
           StudyUiTrans
           );
    }

    void GetStoryState(int TrashNum)
    {
        storyState = TrashNum;
        //_variableStorage.TryGetValue("$Story_State", out _storyState);
        Debug.Log($"현재 스토리는 {storyState} 단계입니다");
    }

    public void SetStoryState(float variable)
    {
        _variableStorage.SetValue("$Story_State", variable);
    }

    public void SetGuideBusy(bool variable)
    {
        _variableStorage.SetValue("$isGuideBusy", variable);
    }

    void DisableNextBnt(int num)
    {
        Debug.Log("버튼 없어짐");
        // lineView.continueButton = null;
        dialogNextBtn.SetActive(false);
    }

    void EnableNextBtn(int num)
    {
        dialogNextBtn.SetActive(true);
        // lineView.continueButton = dialogNextBtn;
    }

    void GetNewQuest(int num)
    {
        QuestManager.questManager.AddNewQuest(DataMgr.Quest.quest[num]);
    }

    void NavigatePortal(int BuildNum)
    {
        QuestTrackingController.questTracking.NavigatePortal(BuildNum);
    }
    
    void DisNavigatePortal(int num)
    {
        QuestTrackingController.questTracking.isTrackingFlag = false;
        QuestTrackingController.questTracking.navigator.SetActive(false);
    }

    void CameraOut(int num)
    {
        CameraSwitcher.cameraSwitcher.SwitchPrioroty(_tempCamera);
    }

    void UIInit(int num)
    {
        playerInfo.anchoredPosition = Vector3.zero;
        PlaceInfo.anchoredPosition = Vector3.zero;
        StudyUI.anchoredPosition = Vector3.zero;
    }

    void StudyUiTrans(int num)
    {
        StudyUI.anchoredPosition = new Vector3(0, 165, 0);
    }
    #endregion

    void StoryCheck()
    {
        //상태창 튜토리얼
        if(storyState == 1)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SetStoryState(2);
                Debug.Log("2단계 튜토리얼 시작");
                PopupMgr.instance.ClosePopup(popup);
                PopupMgr.instance.OpenPopup(popup);
                playerInfo.anchoredPosition = new Vector3(0, 185, 0);
                dialogue.anchoredPosition = new Vector3(0, -365, 0);
                lineView.OnContinueClicked();
            }
        }
    }

    public void StoryState_2()
    {
        if(storyState == 2)
        {
            SetStoryState(3);
            lineView.OnContinueClicked();
        }
    }

    public void StoryState_4()
    {
        if (storyState == 4)
        {
            SetStoryState(5);
            storyState = 5;
            lineView.OnContinueClicked();
            StudyUI.anchoredPosition = new Vector3(0, 165, 0);
        }
    }

    public void StoryState_5()
    {
        if (storyState == 5)
        {
            SetStoryState(6);
            PopupMgr.instance.OpenPopup(popup);
            dialogueRunner.StartDialogue("Guide");
        }
    }

    public void PortalIn()
    {
        Debug.Log(storyState);
        switch (storyState)
        {
            case 4:
                SetStoryState(4);
                SetGuideBusy(true);
                PopupMgr.instance.OpenPopup(popup);
                dialogueRunner.StartDialogue("Guide");
                PlaceInfo.anchoredPosition = new Vector3(0, 165, 0);
                dialogue.anchoredPosition = new Vector3(0, -365, 0);
                break;
        }
    }
}
