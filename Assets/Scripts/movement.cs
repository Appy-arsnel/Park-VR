using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
public class movement : MonoBehaviour
{
   [SerializeField]private float _speed = 7f;
    [SerializeField]private float _mouseSensitivity = 50f;
    [SerializeField]private float _minCameraview = -70f, _maxCameraview = 80f;
    private CharacterController _charController;
    [SerializeField] private Camera _fppcamera;
        //[SerializeField] private Camera _tppcamera;
        private Camera _camera =null;
        bool istpp;
          //[SerializeField] private GameObject _tppc;
                    [SerializeField] private GameObject _fppc,cinebitch;
    public DialogueManager dm;

    public bool canmove;
    private int n;
    private bool iswaving;
    private float xRotation = 0f;
         Vector3 moveVector;
         private bool iswalking,is_movingToNpc,is_movingToFlower,is_movingToPlayground,is_movingTOSwing,is_movingTOSlide;
 private Animator animator;
  float vertical,horizontal;
  [SerializeField] private GameObject[] walkpositions,lookAtWhileWalk;
    // Start is called before the first frame update
    void Start()
    {       canmove=true;
        _charController = GetComponent<CharacterController>();
        _fppc.SetActive(true);
                //_tppc.SetActive(false);

       _camera = _fppcamera;


       istpp=false;

        if(_charController == null)
        Debug.Log("No Character Controller Attached to Player");

        Cursor.lockState = CursorLockMode.Locked;
        animator= GetComponent<Animator>();
        iswalking=false;
        is_movingToNpc=is_movingToFlower=is_movingToPlayground=is_movingTOSwing=is_movingTOSlide=false;
    }
    IEnumerator waiter()
{       canmove=false;
     animator.SetBool("iswaving",true);
    yield return new WaitForSeconds(2);
   animator.SetBool("iswaving",false);
       yield return new WaitForSeconds(1);

           canmove=true;

}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
        if(is_movingToFlower==false&&is_movingToPlayground==false&&is_movingTOSwing==false&&is_movingTOSlide==false)
        is_movingToNpc=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
        if(is_movingToNpc==false&&is_movingToPlayground==false&&is_movingTOSwing==false&&is_movingTOSlide==false)
        is_movingToFlower=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
        if(is_movingToFlower==false&&is_movingToNpc==false&&is_movingTOSwing==false&&is_movingTOSlide==false)
        is_movingToPlayground=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
        if(is_movingToFlower==false&&is_movingToNpc==false&&is_movingTOSwing==false&&is_movingToPlayground==false)
        is_movingTOSlide=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
        if(is_movingToFlower==false&&is_movingToNpc==false&&is_movingToPlayground==false&&is_movingTOSlide==false)
        is_movingTOSwing=true;
        }
        

        if(is_movingToNpc)
        Move_Towards_NPC(0,lookAtWhileWalk[0],ref is_movingToNpc);
        if(is_movingToFlower)
        Move_Towards_NPC(1,lookAtWhileWalk[1],ref is_movingToFlower);
        if(is_movingToPlayground)
        Move_Towards_NPC(2,lookAtWhileWalk[2],ref is_movingToPlayground);
        if(is_movingTOSlide)
        Move_Towards_NPC(3,lookAtWhileWalk[3],ref is_movingTOSlide);
        if(is_movingTOSwing)
        Move_Towards_NPC(4,lookAtWhileWalk[4],ref is_movingTOSwing);
        

        //Get WASD Input for Player
       // _camera.SetActive(true);

       if(canmove){
             vertical = Input.GetAxis("Vertical");
         horizontal = Input.GetAxis("Horizontal");
        //move player based on WASD Input
        Vector3 movement = transform.forward * vertical + transform.right * horizontal; //changed this line.
        _charController.Move(movement * Time.deltaTime * _speed);

       }

        //Get Mouse position Input
        if (!dm.isTalking)
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity; //changed this line.
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity; //changed this line.
                                                                         //Rotate the camera based on the Y input of the mouse
            xRotation -= mouseY;
            //clamp the camera rotation between 80 and -70 degrees
            xRotation = Mathf.Clamp(xRotation, _minCameraview, _maxCameraview);
            

            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            //Rotate the player based on the X input of the mouse
            transform.Rotate(Vector3.up * mouseX * 3);
        }
        
            
            moveVector = Vector3.zero;
 
         //Check if cjharacter is grounded
         if (_charController.isGrounded == false)
         {
             //Add our gravity Vector
             moveVector += Physics.gravity;
         }
 
         //Apply our move Vector , remeber to multiply by Time.delta
         _charController.Move(moveVector * Time.deltaTime);


         
        //float horizontal = Input.GetAxis("Horizontal");
            if(Input.GetKeyDown(KeyCode.C)){
            if(istpp==false){
            //_camera=_tppcamera;
            _fppc.SetActive(false);
                //_tppc.SetActive(true);
            istpp=true;
        }
        else if(istpp==true){
            _camera=_fppcamera;
            _fppc.SetActive(true);
                //_tppc.SetActive(false);
            istpp=false;
        }
        
        }
            
        if(Input.GetKeyDown(KeyCode.Y)){
                           
                        StartCoroutine(waiter());
        }
                
            //      if(n%2==0){
            //                 iswaving=true;
            //                 n++;
            //     }
            //     else{
            //                     iswaving=false;
            //                     n++;
            //     }
             
        
        }

    private void Move_Towards_NPC(int i,GameObject obj, ref bool isMove)
    {
        var offset =walkpositions[i].transform.position-this.transform.position;
       
        if(offset.magnitude<=0.2){

            isMove=false;
            Debug.Log("false ho gaya");
        }
        offset=offset.normalized*_speed;
        _charController.Move(offset*Time.deltaTime);
        this.transform.LookAt(obj.transform);
    }

    void FixedUpdate() {
             // _camera.SetActive(true);
               if(vertical>0||vertical<0||horizontal>0||horizontal<0){
                         animator.SetBool("isWalking",true);
              


            }
            else if(horizontal==0&&vertical==0){
             animator.SetBool("isWalking",false);

            }
            else{
                  animator.SetBool("isWalking",false);
            }
            // if(iswaving){
            //     animator.SetBool("iswaving",true);
            //     canmove=false;
            // }
            // else{
            //                     animator.SetBool("iswaving",false);
            //                     canmove=true;

            // }

            
        
    }
    
}