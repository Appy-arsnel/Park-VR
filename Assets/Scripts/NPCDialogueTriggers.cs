using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueTriggers : MonoBehaviour
{
    public bool isGuide;
    public bool isFlowerBox;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask1;
    public LayerMask layerMask2;
    private Vector3 origin;

    public GameObject guide;
    public GameObject flowerBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;      
        if(Physics.CheckSphere(origin, sphereRadius, layerMask1))
        {
            isGuide = true;
            //Debug.Log("hit");
        } else if (Physics.CheckSphere(origin, sphereRadius, layerMask2))
        {
            isFlowerBox = true;
        }else
        {
            isGuide = false;
            isFlowerBox = false;
        }

        if (isGuide)
        {
            guide.GetComponent<DialogueManager>().Convo();
        } else if (isFlowerBox)
        {
            flowerBox.GetComponent<DialogueManager>().Convo();
        }

        /*if (isFlowerBox)
        {
            flowerBox.GetComponent<DialogueManager>().Convo();
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, sphereRadius);
    }

    
}
