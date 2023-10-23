using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTabController : MonoBehaviour
{
    [SerializeField] Button initButton;
    private QuestManager _questManager;

    private void Start()
    {
        _questManager = QuestManager.questManager;
    }

    public void OnClickQuestTab()
    {
        _questManager.MakeQuestObject();
    }

    private void OnDisable()
    {
        initButton.onClick.Invoke();
    }
}
