using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class transportation : MonoBehaviour
{
    public DialogueManager dm;
    public GameObject arrow;
    public GameObject flowerBoxPosition;
    public GameObject playgroundPosition;
    public Vector3 playerPos;
    public float _fadeDuration = 2f;
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
                    StartCoroutine(ChangePositionPlayerToGuide());
                    FadeFromBlack();
                    transported = true;

                }
                if (dm.i == 5)
                {
                    StartCoroutine(ChangePositionPlayerToPlayGround());
                    FadeFromBlack();
                    transported = true;
                }
            }
            
        } else
        {
            if((dm.i ==2||dm.i==3||dm.i ==4) && Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(ChangePositionGuideToPlayer());
                FadeFromBlack();
                transported = false;
            } else if (dm.i == 5 && Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(ChangePositionPlayGroundToPlayer());
                FadeFromBlack();
                transported = false;
            }
        }

        if (dm.dt.isFlowerBox)
        {
            if(dm.i == 2)
            {
                arrow.SetActive(true);
                arrow.transform.position = new Vector3(37.5480003f, -3.18799996f, 72.3980026f);
            } else if (dm.j == 3)
            {
                arrow.transform.position = new Vector3(37.5480003f, -3.18799996f, 71.6660004f);
            } else if(dm.j == 4)
            {
                arrow.transform.position = new Vector3(37.5480003f, -3.18799996f, 70.9830017f);
            }
        }
        
    }
    private void FadeFromBlack()
    {
        SteamVR_Fade.Start(Color.black, 0f);
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }

    IEnumerator ChangePositionGuideToPlayer()
    {
        yield return new WaitForSeconds(1f);
        dm.dialogueUI.transform.position = new Vector3(37.533f, -2.87f, 75.679f);
        dm.i = 1;
        dm.npcDialogueBox.text = dm.npc.dialogue[dm.i];
        gameObject.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        arrow.SetActive(false);
    }

    IEnumerator ChangePositionPlayerToGuide()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector3(flowerBoxPosition.transform.position.x, flowerBoxPosition.transform.position.y, flowerBoxPosition.transform.position.z);
        dm.dialogueUI.transform.position = new Vector3(37.542f, -2.557f, 71.71f);
    }

    IEnumerator ChangePositionPlayGroundToPlayer()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);

    }

    IEnumerator ChangePositionPlayerToPlayGround()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector3(playgroundPosition.transform.position.x, playgroundPosition.transform.position.y, playgroundPosition.transform.position.z);
    }

}
