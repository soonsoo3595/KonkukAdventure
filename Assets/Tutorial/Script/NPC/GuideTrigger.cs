using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GuideTrigger : MonoBehaviour
{
    [SerializeField] DialogueRunner guideDialogu;
    private Popup popup;

    private void OnTriggerEnter(Collider other)
    {
        GuideDialogu();
    }

    private void OnTriggerExit(Collider other)
    {
        PopupMgr.instance.ClosePopup(popup);
    }

    void GuideDialogu()
    {
        popup = PopupMgr.instance.dialoguePopup;
        PopupMgr.instance.OpenPopup(popup);
        guideDialogu.StartDialogue("Guide");
    }
}
