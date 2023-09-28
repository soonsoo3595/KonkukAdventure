using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUiController : MonoBehaviour
{
    [SerializeField] Transform questContentTrans;

    private QuestManager _questManager;

    private void Start()
    {
        _questManager = QuestManager.questManager;   
    }

    public void OnClickQuestTab()
    {
        foreach(GameObject questObject in _questManager.questObjectList)
        {
            questObject.transform.SetParent(questContentTrans);
            questObject.transform.position = new Vector3(questObject.transform.position.x, transform.position.y, 0);
            questObject.transform.eulerAngles = Vector3.zero;
            questObject.transform.localScale = Vector3.one;
            questObject.SetActive(true);
        }
    }
}
