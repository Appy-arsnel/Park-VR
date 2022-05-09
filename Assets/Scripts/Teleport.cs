using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Teleport : MonoBehaviour
{
    public GameObject fb;
    public GameObject pg;
    public GameObject gd;
    public bool isThere = false;
    public DialogueManager dm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(dm.i == 1)
            {
                if (!isThere)
                {
                    StartCoroutine(TeleportationToFB());
                    isThere = true;
                }
                else
                {
                    StartCoroutine(TeleportationToGD());
                    isThere = false;
                }
            } else if(dm.i == 2)
            {
                if (!isThere)
                {
                    StartCoroutine(TeleportationToPG());
                    isThere = true;
                }
                else
                {
                    StartCoroutine(TeleportationToGD());
                    isThere = false;
                }
            }
            
        }
        
        
    }

    IEnumerator TeleportationToFB()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector3(fb.transform.position.x, fb.transform.position.y, fb.transform.position.z);
        
    }
    IEnumerator TeleportationToGD()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(gd.transform.position.x, gd.transform.position.y, gd.transform.position.z);
        
    }

    IEnumerator TeleportationToPG()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(pg.transform.position.x, pg.transform.position.y, pg.transform.position.z);

    }
}
