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
       
        SwitchState();
        
    }

    private void SwitchState()
    {
        if (dm.i == 1)
        {
            anim.Play("Grass");
            
        } else if(dm.i == 2)
        {
            anim.Play("PlayGround");
        } else
        {
            anim.Play("FPOV");
        }
        
    }
}
