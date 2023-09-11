using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<QuestData> quests;

    private GameObject _player;

    private void Start()
    {
        _player = GameManager.instance.player;
    }

    void SetQuest(QuestData quest)
    {
        quests.Add(quest);
    }

    void PopQuest(QuestData quest)
    {
        quests.Remove(quest);
    }

    public bool QuestCheck(int destination)
    {
        foreach(QuestData quest in quests)
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
