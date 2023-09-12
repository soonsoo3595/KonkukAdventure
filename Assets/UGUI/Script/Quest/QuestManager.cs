using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] GameObject questObject;
    [SerializeField] GameObject questObjectPool;

    internal List<GameObject> questObjectList;

    private List<QuestData> _quests;

    private void Awake()
    {
        _quests = new List<QuestData>();
        questObjectList = new List<GameObject>();
    }

    void SetQuest(QuestData quest)
    {
        GameObject instance = Instantiate(questObject, questObjectPool.transform);
        questObjectList.Add(instance);
        _quests.Add(quest);
        instance.SetActive(false);
    }

    void PopQuest(QuestData quest)
    {
        _quests.Remove(quest);
    }

    public bool QuestCheck(int destination)
    {
        foreach(QuestData quest in _quests)
        {
            if (quest.destination.Equals(destination))
            {
                QuestComplete(quest);
                return true;
            }
        }
        return false;
    }

    void QuestComplete(QuestData quest)
    {
        ///QuestData를 사용하는 quest 다이얼로그를팝업 합니다.
        ///해당 작업을 하기 위해서 popUp Manager를 사용하여 작업합니다.
    }
}
