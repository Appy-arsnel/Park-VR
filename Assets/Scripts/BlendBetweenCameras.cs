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
    public GameObject Arrow;

        void Start(){
            Arrow.SetActive(false);
        }
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
             if (dm.i == 4 || dm.i == 5)
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
        //   FPOVCamera = false;
         // StartCoroutine(FPOV_true());
        } 
        else if(dm.i==2){
                  
            Arrow.SetActive(true);
            Arrow.transform.position=new Vector3(37.5480003f,-3.18799996f,72.3980026f);
        }
         else if(dm.i==3){
             Arrow.transform.position=new Vector3(37.5480003f,-3.18799996f,71.6660004f);
        }
         else if(dm.i==4){
             Arrow.transform.position=new Vector3(37.5480003f,-3.18799996f,70.9830017f);
        }
        else if(dm.i == 5)
        { Arrow.SetActive(false);
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
     IEnumerator FPOV_true()
    {
        yield return new WaitForSeconds(1f);
                FPOVCamera=true;
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
