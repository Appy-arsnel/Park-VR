using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendBetweenCameras : MonoBehaviour
{
    public DialogueManager dm;
    public Animator anim;
    public bool FPOVCamera = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        if (FPOVCamera && dm.i == 1)
        {
            anim.Play("Grass");
        } else if(FPOVCamera && dm.i == 2)
        {
            anim.Play("PlayGround");
        } else
        {
            anim.Play("FPOV");
        }
        FPOVCamera = !FPOVCamera;
    }
}
