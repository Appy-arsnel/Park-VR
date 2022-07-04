using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public bool isGuide = false;
    public LayerMask layerMask;
    private Vector3 origin;
    public float sphereRadius;

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        if(Physics.CheckSphere(origin, sphereRadius, layerMask))
        {
            isGuide = true;
            
        } /*else
        {
            isGuide = false;
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, sphereRadius);
    }
}
