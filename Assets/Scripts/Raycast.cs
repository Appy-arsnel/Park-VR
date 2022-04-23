using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public bool isGuide = false;
    public LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 4f, layerMask)){
            isGuide = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        } else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4f, Color.green);
        }
    }
}
