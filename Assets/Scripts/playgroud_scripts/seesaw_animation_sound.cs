using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seesaw_animation_sound : MonoBehaviour
{
    // Start is called before the first frame update
    //variable to rotate seesaw
    public GameObject to_rotate;

    void Start()
    {
        // to_rotate.transform.Rotate=new Vector3(-0.205f,-0.001f,11.758f);
        // to_rotate.position.position=new Vector3(0.005087582f,2.004576f,0.002937317f);
        to_rotate.transform.Rotate(6.135f,0.615f,-7.617f);
        to_rotate.transform.position=new Vector3(-0.3132511f,1.834898f,-0.089147f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
