using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestObjectController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questName;
    [SerializeField] TextMeshProUGUI questExplain;
    [SerializeField] TextMeshProUGUI questReward;

    private int _id;
    private int _destination;
    private string _explain;
    private int _reward;
    private int _nextQuest;
    private bool _isQuestDone;

    /// <summary>
    /// 생성된 퀘스트 오브젝트에 받아온 정보를 입력하는 메서드 입니다.
    /// </summary>
    /// <param name="questdata">다음 파라미터를 통해 오브젝트에 해당하는 정보를 가져온 뒤,
    /// 해당 정보를 변수에 입히고 화면에 띄워준다.</param>
    public void GetData(QuestData questdata)
    {
        _id = questdata.questID;
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
        questName.text = _id.ToString();
        questExplain.text = _destination.ToString();
        questReward.text = _explain.ToString();
    }
}
