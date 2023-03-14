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

    public GameObject player,fpp,tpp;
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
        isTalking=false;    
        
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
    {   fpp.SetActive(true);
        tpp.SetActive(false);
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
       tpp.SetActive(true);
       fpp.SetActive(false);
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
                    
                    if (isTalking == true && i == 6)
                    {
                        StartCoroutine(waving_waiter());
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
                /*if(blendBC.flowerBox)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (isTalking == true && i < 4)
                        {
                            i++;
                            npcDialogueBox.text = npc.dialogue[i];
                            blendBC.redialog = false;

                        } else if(isTalking == true && i == 4)
                        {
                            i = 2;
                            npcDialogueBox.text = npc.dialogue[i];
                            blendBC.redialog = false;
                        }
                        
                    }
                } else
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        
                        if (isTalking == true && i < npc.dialogue.Length - 1)
                        {
                            if(i == 1)
                            {
                                i = 5;
                                npcDialogueBox.text = npc.dialogue[i];
                                blendBC.redialog = false;
                            }else
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
                }
                
            }*/
            
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