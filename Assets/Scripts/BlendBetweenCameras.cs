using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class BlendBetweenCameras : MonoBehaviour
{
    public DialogueManager dm;
    public Animator anim;
    public bool FPOVCamera = false;
    public bool TPPCamera = true;
    public float timer1;

    // Update is called once per frame
    void Update()
    {
        if(FPOVCamera == true)
        {
            SwitchState();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchPOV();
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
            timer1 = 7f;
        } else if(dm.i == 2)
        {
            anim.Play("PlayGround");
            StartCoroutine(HideDialogBox());
            StartCoroutine(BackToGuideFromPG());
            StartCoroutine(ShowDialogBoxPG());
            timer1 = 8f;
        } else
        {
            anim.Play("FPOV");
        }
        FPOVCamera = !FPOVCamera;
    }

    private void SwitchPOV()
    {
        if (TPPCamera)
        {
            anim.Play("TPOV");
        } else
        {
            anim.Play("FPOV");
        }
        TPPCamera = !TPPCamera;
    }

    IEnumerator HideDialogBox()
    {
        yield return new WaitForSeconds(2f);
        dm.dialogueUI.SetActive(false);
    }

    IEnumerator BackToGuide()
    {
        yield return new WaitForSeconds(5f);
        //FPOVCamera = false;
        anim.Play("FPOV");
    }

    IEnumerator ShowDialogBox()
    {
        yield return new WaitForSeconds(7f);
        dm.dialogueUI.SetActive(true);
    }

    IEnumerator BackToGuideFromPG()
    {
        yield return new WaitForSeconds(6f);
        //FPOVCamera = false;
        anim.Play("FPOV");
    }

    IEnumerator ShowDialogBoxPG()
    {
        yield return new WaitForSeconds(8f);
        dm.dialogueUI.SetActive(true);
    }
}
