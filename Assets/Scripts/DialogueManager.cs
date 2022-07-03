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

    public NPCDialogueTriggers dt;

    public Text npcName;
        
    public Text npcDialogueBox;

    

//npc animations
     private Animator animator;
     private bool is_waving;

    //public BlendBetweenCameras blendBC;
    [HideInInspector]
    public int i = 0;
    [HideInInspector]
    public int j = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        animator= GetComponent<Animator>();
    }

    void Update()
    {
        /*if (dt.isGuide)
        {
            Convo();
        }*/

        /*if (blendBC.timer1 > 0f)
        {
            blendBC.timer1 -= Time.deltaTime;
        }
        if(blendBC.timer1 < 0f)
        {
            blendBC.timer1 = 0f;
        }*/
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
        
    }
   IEnumerator waving_waiter()
{     
     animator.SetBool("iswaving",true);
    yield return new WaitForSeconds(2);
   animator.SetBool("iswaving",false);
      

           

}
    public void Convo()
    {
        //trigger dialogue
        if (dt.isGuide)
        {
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
                StartCoroutine(waving_waiter());

            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
                StartCoroutine(waving_waiter());
                i = 0;
            }
            if (isTalking == true && Input.GetKeyDown(KeyCode.Space) && i < npc.dialogue.Length - 1)
            {
                i++;
                npcDialogueBox.text = npc.dialogue[i];

            }
            else if (isTalking == true && Input.GetKeyDown(KeyCode.Space) && i == npc.dialogue.Length - 1)
            {
                EndDialogue();
                StartCoroutine(waving_waiter());
                i = 0;
            }
        }

        else if (dt.isFlowerBox)
        {
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            } else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
                j = 0;
            }
            if(isTalking == true && Input.GetKeyDown(KeyCode.Space))
            {
                if (j < npc.dialogue.Length - 1)
                {
                    j++;
                    npcDialogueBox.text = npc.dialogue[j];
                } else if(j == npc.dialogue.Length - 1)
                {
                    j = 0;
                    npcDialogueBox.text = npc.dialogue[j];
                }
            }
        }
        

        /*if(blendBC.timer1 == 0f)
        {
            if (blendBC.FPOVCamera)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (isTalking == true && i < npc.dialogue.Length - 1)
                    {
                        if (i == 1)
                        {
                            i = 5;
                            npcDialogueBox.text = npc.dialogue[i];
                            blendBC.redialog = false;
                        }
                        else
                        {
                            i++;
                            npcDialogueBox.text = npc.dialogue[i];
                            blendBC.redialog = false;
                        }
                    }
                    else if (isTalking == true && i == npc.dialogue.Length - 1)
                    {
                        EndDialogue();
                        blendBC.redialog = false;
                    }
                }
            } else
            {
                if (blendBC.flowerBox)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (isTalking == true && i < 4)
                        {
                            i++;
                            npcDialogueBox.text = npc.dialogue[i];
                            blendBC.redialog = false;

                        }
                        else if (isTalking == true && i == 4)
                        {
                            i = 2;
                            npcDialogueBox.text = npc.dialogue[i];
                            blendBC.redialog = false;
                        }

                    }
                }
            }            
        }*/

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