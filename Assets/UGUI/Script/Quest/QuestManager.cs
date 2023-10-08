using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    [SerializeField] GameObject questObject;
    [SerializeField] Transform questContentTrans;

    [SerializeField] internal List<GameObject> questObjectList;
    [SerializeField] private List<QuestData> _quests;
    [SerializeField] private List<QuestData> _newQuests;

    private void Awake()
    {
        questManager = this;
        _quests = new List<QuestData>();
        questObjectList = new List<GameObject>();
    }

    private void Start()
    {
        ///test 코드
        AddQuest(DataMgr.Quest);
        AddQuest(DataMgr.Quest);
        AddQuest(DataMgr.Quest);
    }

    void AddQuest(QuestData quest)
    {
        _newQuests.Add(quest);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            for(int i =0; i< _quests.Count; i++)
            {
                QuestComplete(_quests[i]);
            }
        }
    }

    public void MakeQuestObject()
    {
        ///퀘스트 탭을 클릭하면 무조건 완료된 퀘스트가 있는지 체크한다.
        ///퀘스트가 갱신되었을 경우
        for (int i = _quests.Count-1; i >=0; i--)
        {
            if (_quests[i].quest_Done.Equals(true))
            {
                _quests.Remove(_quests[i]);
                Destroy(questObjectList[i]);
                questObjectList.RemoveAt(i);
            }
        }

        ///퀘스트가 추가 된 경우
        if (_newQuests.Count > 0)
        {
            for (int i = 0; i < _newQuests.Count; i++)
            {
                ///기존 퀘스트 목록에 새로운 퀘스트 추가
                _quests.Add(_newQuests[i]);

                GameObject newQuest = Instantiate(questObject, questContentTrans);
                newQuest.GetComponent<QuestObjectController>().GetData(_newQuests[i]);
                questObjectList.Add(newQuest);
            }

            _newQuests.Clear();
        }
    }

    /// <summary>
    /// 퀘스트수행을 체크
    /// 포탈에 도착하면 무조건 실행하는 메서드
    /// </summary>
    /// <param name="destination"> 포탈의 이름 </param>
    /// <returns>faㅣse 이면 갱신 불필요</returns>
    public bool QuestCheck(int destination)
    {
        foreach (QuestData quest in _quests)
        {
            return QuestComplete2(quest, destination);
        }
        return false;
    }

    /// <summary>
    /// 퀘스트 오브젝트의 내부 파라미터 quest_Done을 True로 만들어주는 메서드 입니다.
    /// </summary>
    /// <param name="quest"> QuestCheck 메서드에서 검사하는 quest 오브젝트가 들어갑니다. </param>
    bool QuestComplete2(QuestData quest, int destination)
    {
        if (quest.destination.Equals(destination))
        {
            quest.quest_Done = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 퀘스트 오브젝트의 내부 파라미터 quest_Done을 True로 만들어주는 메서드 입니다.
    /// </summary>
    /// <param name="quest"> QuestCheck 메서드에서 검사하는 quest 오브젝트가 들어갑니다. </param>
    void QuestComplete(QuestData quest)
    {
        quest.quest_Done = true;
    }
}
