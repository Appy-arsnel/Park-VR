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
    public GameObject dialogueUI,arrow;
    public float timer;
    public Raycast rc;

    public Text npcName;
        
    public Text npcDialogueBox;

//npc animations
     private Animator animator;
     private bool is_waving;

    public BlendBetweenCameras blendBC;
    [HideInInspector]
    public int i = 0;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        animator= GetComponent<Animator>();
        arrow.SetActive(false);
        
    }

    void Update()
    {
        if (rc.isGuide)
        {
            Convo();
        }

        
        // if (blendBC.timer1 > 0f)
        // {
        //     blendBC.timer1 -= Time.deltaTime;
        // }
        // if(blendBC.timer1 < 0f)
        // {
        //     blendBC.timer1 = 0f;
        // }
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
            playerPos = player.transform.position;
          StartCoroutine(waving_waiter());
        
        }
        else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
        {
            EndDialogue();
           StartCoroutine(waving_waiter());
        }

        // if(blendBC.timer1 == 0f)
        // {
        //     if (blendBC.FPOVCamera)
        //     {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (isTalking == true && i < npc.dialogue.Length - 1)
                    {
                        
                        if (i == 1)
                        {   arrow.SetActive(true);
//StartCoroutine(dialogueCanvasChange(-4.76000023f, 0.558000028f, 1.74800003f));
                            //StartCoroutine(playerChange(36.0186005f, -3.7019546f, 71.5500031f));
                            dialogueUI.transform.localPosition= new Vector3(-4.76000023f,0.558000028f,1.74800003f);  
                            player.transform.position=new Vector3(36.0186005f,-3.7019546f,71.5500031f);
                        }
                         if (i == 2)
                        {   arrow.transform.position= new Vector3(37.5480003f,-3.18799996f,71.6719971f);
                           
                        }
                         if (i == 3)
                        {   arrow.transform.position= new Vector3(37.5480003f,-3.18799996f,72.4830017f);
                            
                        }
                         if (i == 4)
                        {
                    arrow.transform.position = new Vector3(37.548f, -3.188f, 70.983f);
                    //StartCoroutine(dialogueCanvasChange(-16.1700001f, 0.558000028f, 2.00999999f));
                    //StartCoroutine(playerChange(36.0186005f, -3.7019546f, 61.9399986f));
                    dialogueUI.transform.localPosition= new Vector3(-16.1700001f,0.558000028f,2.00999999f);  
                             player.transform.position=new Vector3(36.0186005f,-3.7019546f,61.9399986f);
                        }
                         if(i == 5)
                {
                    //StartCoroutine(dialogueCanvasChange(0.08599716f, 0.5910001f, 0.6440006f));
                    //StartCoroutine(playerChange(playerPos.x, playerPos.y, playerPos.z));
                    dialogueUI.transform.localPosition = new Vector3(0.08599716f, 0.5910001f, 0.6440006f);
                    player.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
                }
                if (i == 6)
                {
                    StartCoroutine(waving_waiter());
                }
                            ++i;
                            npcDialogueBox.text = npc.dialogue[i];
                           
                        }
                          else if (isTalking == true && i == npc.dialogue.Length - 1)
                    {
                          arrow.SetActive(false);
                          EndDialogue();
                       
                        
                        

            }
                    }
                  
                
            // } else
            // {
            //     if (blendBC.flowerBox)
            //     {
            //         if (Input.GetKeyDown(KeyCode.Space))
            //         {
            //             if (isTalking == true && i < 4)
            //             {
            //                 i++;
            //                 npcDialogueBox.text = npc.dialogue[i];
            //                 blendBC.redialog = false;

            //             }
            //             else if (isTalking == true && i == 4)
            //             {
            //                 i = 2;
            //                 npcDialogueBox.text = npc.dialogue[i];
            //                 blendBC.redialog = false;
            //             }

            //         }
            //     }
            // }
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
            
        //}
  
    }
     void FixedUpdate()
    {
        if(is_waving){
             animator.SetBool("iswaving",true);

        }else{
             animator.SetBool("iswaving",false);
        }
    }

    IEnumerator dialogueCanvasChange(float x, float y, float z)
    {
        yield return new WaitForSeconds(1f);
        dialogueUI.transform.position = new Vector3(x, y, z);
    }

    IEnumerator playerChange(float x, float y, float z)
    {
        yield return new WaitForSeconds(1.5f);
        player.transform.position = new Vector3(x, y, z);
    }
}
