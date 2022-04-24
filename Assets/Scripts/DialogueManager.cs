using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    public bool isTalking = false;

    float distance;

    public GameObject player;
    public GameObject dialogueUI;

    public Raycast rc;

    public Text npcName;
        
    public Text npcDialogueBox;

//npc animations
     private Animator animator;
     private bool is_waving;

    public BlendBetweenCameras blendBC;
    [HideInInspector]
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        animator= GetComponent<Animator>();
    }

    void Update()
    {
        if (rc.isGuide)
        {
            Convo();
        }

        if (blendBC.timer1 > 0f)
        {
            blendBC.timer1 -= Time.deltaTime;
        }
        if(blendBC.timer1 < 0f)
        {
            blendBC.timer1 = 0f;
        }
    }

    void StartConversation()
    {
        isTalking = true;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
        i = 0;
    }
   IEnumerator waving_waiter()
{     
     animator.SetBool("iswaving",true);
    yield return new WaitForSeconds(2);
   animator.SetBool("iswaving",false);
      

           

}
    void Convo()
    {
        //trigger dialogue
        if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
        {
            StartConversation();
          StartCoroutine(waving_waiter());
        
        }
        else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
        {
            EndDialogue();
           StartCoroutine(waving_waiter());
        }

        if(blendBC.timer1 == 0f)
        {
            if (isTalking == true && Input.GetKeyDown(KeyCode.Space) && i < npc.dialogue.Length - 1)
            {
                i++;
                npcDialogueBox.text = npc.dialogue[i];
                blendBC.FPOVCamera = true;

            }
            else if (isTalking == true && Input.GetKeyDown(KeyCode.Space) && i == npc.dialogue.Length - 1)
            {
                EndDialogue();
            }
        }
        
    }
     void FixedUpdate()
    {
        if(is_waving){
             animator.SetBool("iswaving",true);

        }else{
             animator.SetBool("iswaving",false);
        }
    }

}