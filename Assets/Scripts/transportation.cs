using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transportation : MonoBehaviour
{
    public DialogueManager dm;
    public GameObject arrow;
    public GameObject flowerBoxPosition;
    public GameObject playgroundPosition;
    public Vector3 playerPos;
    
    public bool transported;
    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!transported)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                playerPos = this.transform.position;
                if (dm.i == 1)
                {
                    this.transform.position = flowerBoxPosition.transform.position;
                    dm.dialogueUI.transform.position = new Vector3(37.542f, -2.557f, 71.71f);
                    transported = true;
                }
                if (dm.i == 2)
                {
                    this.transform.position = playgroundPosition.transform.position;
                    transported = true;
                }
            }
            
        } else
        {
            if((dm.dt.isGuide || dm.dt.isFlowerBox) && Input.GetKeyDown(KeyCode.T))
            {
                this.transform.position = playerPos;
                transported = false;
            }
        }

        if (dm.dt.isFlowerBox)
        {
            if(dm.j == 0 && dm.isTalking)
            {
                arrow.SetActive(true);
                arrow.transform.position = new Vector3(37.5480003f, -3.18799996f, 72.3980026f);
            } else if (dm.j == 1 && dm.isTalking)
            {
                arrow.transform.position = new Vector3(37.5480003f, -3.18799996f, 71.6660004f);
            } else if(dm.j == 2 && dm.isTalking)
            {
                arrow.transform.position = new Vector3(37.5480003f, -3.18799996f, 70.9830017f);
            }
        }
        
    }
}
