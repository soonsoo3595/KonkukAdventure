using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PopupAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        if (CompareTag("InstancePopup"))
        {
            StartCoroutine(Opne());
        }
    }

    private void OnDisable()
    {
        
        this.gameObject.SetActive(false);
    }

    IEnumerator Opne()
    {
        yield return new WaitForSeconds(0.7f);
        Animator anim = GetComponent<Animator>();
        anim.SetBool("close", true);
    }
}
