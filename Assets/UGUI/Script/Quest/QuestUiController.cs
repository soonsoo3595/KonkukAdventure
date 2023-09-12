using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUiController : MonoBehaviour
{
    [SerializeField] Transform questContentTrans;

    private QuestManager _questManager;

    private void Start()
    {
        _questManager = GameManager.instance.questManager;    
    }

    public void OnClickQuestTab()
    {
        foreach(GameObject questObject in _questManager.questObjectList)
        {
            questObject.transform.parent = questContentTrans;
            questObject.SetActive(true);
        }
    }
}
