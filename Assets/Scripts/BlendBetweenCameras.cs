using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class BlendBetweenCameras : MonoBehaviour
{
    public DialogueManager dm;
    public Animator anim;
    public bool FPOVCamera = true;

    // Update is called once per frame
    void Update()
    {
        if(FPOVCamera == true)
        {
            SwitchState();
        }        
    }

    private void SwitchState()
    {
        if (dm.i == 1)
        {
            anim.Play("FlowerBox");
            StartCoroutine(HideDialogBox());
            StartCoroutine(BackToGuide());
            StartCoroutine(ShowDialogBox());

        } else if(dm.i == 2)
        {
            anim.Play("PlayGround");
            StartCoroutine(HideDialogBox());
            StartCoroutine(BackToGuide());
            StartCoroutine(ShowDialogBox());
        } else
        {
            anim.Play("FPOV");
        }
    }

    IEnumerator HideDialogBox()
    {
        yield return new WaitForSeconds(2.1f);
        dm.dialogueUI.SetActive(false);
    }

    IEnumerator BackToGuide()
    {
        yield return new WaitForSeconds(4.1f);
        FPOVCamera = false;
        anim.Play("FPOV");
    }

    IEnumerator ShowDialogBox()
    {
        yield return new WaitForSeconds(6.3f);
        dm.dialogueUI.SetActive(true);
    }
}
