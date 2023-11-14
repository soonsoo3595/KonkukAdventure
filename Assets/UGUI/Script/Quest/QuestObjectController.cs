using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestObjectController : MonoBehaviour
{
    /// <summary>
    /// QuestManager에서 위임하는 델리게이트 입니다.
    /// 퀘스트 완료 버튼을 누르면 QuestManager에있는 배열들 안에 있는
    /// 이 오브젝트의 정보가 삭제됩니다.
    /// </summary>
    /// <param name="questObject">이 오브젝트 즉, This.gameObject 가 들어가야 합니다.</param>
    public delegate void DeleteQuest(GameObject questObject);
    public static event DeleteQuest Delete;

    /// <summary>
    /// QuestTrackingController에서 위임하는 델리게이트 입니다.
    /// 포탈들의 정보를 가져오고, 화살표를 표시해 목적지를 가리킵니다.
    /// </summary>
    /// <param name="buildingNum">목적지의 빌딩 번호가 필요합니다.</param>
    /// <returns>.</returns>
    public delegate bool TrackingQuest(int buildingNum);
    public static event TrackingQuest Tracking;

    [SerializeField] TextMeshProUGUI questName;
    [SerializeField] TextMeshProUGUI questDestination;
    [SerializeField] TextMeshProUGUI questExplain;
    [SerializeField] TextMeshProUGUI isQuestDoneText;
    [SerializeField] TextMeshProUGUI questButtonText;

    public QuestData questdata;

    private int _id;
    private string _name;
    private int _destination;
    private string _explain;
    private int _reward;
    private int _nextQuest;
    private bool _isQuestDone = false;

    /// <summary>
    /// 생성된 퀘스트 오브젝트에 받아온 정보를 입력하는 메서드 입니다.
    /// </summary>
    /// <param name="questdata">다음 파라미터를 통해 오브젝트에 해당하는 정보를 가져온 뒤,
    /// 해당 정보를 변수에 입히고 화면에 띄워준다.</param>
    public void GetData(QuestData questdata)
    {
        this.questdata = questdata;
        _id = questdata.questID;
        _name = questdata.questName;
        _destination = questdata.destination;
        _explain = questdata.quest_Explain;
        _reward = questdata.reward_Credit;
        _nextQuest = questdata.next_Quest;
        _isQuestDone = questdata.quest_Done;

        SetData();
    }
    
    /// <summary>
    /// 받아온 정보로 바뀐 변수들을 이용해
    /// 퀘스트 오브젝트 내의 글자들을 변경한나다,
    /// </summary>
    void SetData()
    {
        questName.text = $"{_name.ToString()}";
        questDestination.text = $"목적지: {_destination.ToString()}";
        questExplain.text = $"설명: {_explain.ToString()}";
        if (_isQuestDone)
        {
            isQuestDoneText.text = "완료";
            questButtonText.text = "퀘스트 완료";
        }
        else
        {
            isQuestDoneText.text = "미완료";
            questButtonText.text = "퀘스트 안내";
        }
    }

    /// <summary>
    /// 퀘스트 버튼이 클릭되었을 때 반응하는 이벤트
    /// 완료되었을 때 누른다면 삭제됩니다.
    /// </summary>
    public void OnClickQuestButton()
    {
        if (_isQuestDone)
        {
            Debug.Log("퀘스트를 완료합니다.");
            QuestTrackingController.questTracking.isTrackingFlag = false;
            QuestTrackingController.questTracking.navigator.gameObject.SetActive(false);
            Delete(this.gameObject);
            return;
        }

        if (Tracking(_destination)) Debug.LogError("존재하지 않는 포탈을 추적하고 있습니다.");

    }
}
