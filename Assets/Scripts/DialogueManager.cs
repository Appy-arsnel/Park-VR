using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    float distance;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;

    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 4f)
        {
            
            //trigger dialogue
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            
            if (isTalking == true && Input.GetKeyDown(KeyCode.Space) && i<npc.dialogue.Length-1)
            {
                i++;
                npcDialogueBox.text = npc.dialogue[i];
            }
            else if(isTalking == true && Input.GetKeyDown(KeyCode.Space) && i == npc.dialogue.Length-1)
            {
                EndDialogue();
            }

            

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

}