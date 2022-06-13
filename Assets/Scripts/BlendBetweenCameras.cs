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
    public bool TPPCamera = true;
    public bool redialog = false;
    public float timer1;

    // Update is called once per frame
    void Update()
    {
        if(FPOVCamera == true && redialog == false)
        {
            SwitchState();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchPOV();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dm.i == 1 || dm.i == 2)
            {
                BackToGuide();
                StartCoroutine(ShowDialogBox());
            }
        }
    }

    private void SwitchState()
    {
        if (dm.i == 1)
        {
            anim.Play("FlowerBox");
            FPOVCamera = false;
            StartCoroutine(HideDialogBox());
        } else if(dm.i == 2)
        {
            anim.Play("PlayGround");
            FPOVCamera = false;
            StartCoroutine(HideDialogBox());
        } else
        {
            anim.Play("FPOV");
        }
        //FPOVCamera = !FPOVCamera;
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

    void BackToGuide()
    {
        //yield return new WaitForSeconds(5f);
        FPOVCamera = true;
        redialog = true;
        anim.Play("FPOV");
    }

    IEnumerator ShowDialogBox()
    {
        yield return new WaitForSeconds(2f);
        dm.dialogueUI.SetActive(true);
    }

    /*IEnumerator BackToGuideFromPG()
    {
        yield return new WaitForSeconds(6f);
        FPOVCamera = false;
        anim.Play("FPOV");
    }

    IEnumerator ShowDialogBoxPG()
    {
        yield return new WaitForSeconds(8f);
        dm.dialogueUI.SetActive(true);
    }*/
}
