using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    private UnityEngine.Vector2 currentVelocity;
    [SerializeField]
    private float movementSpeed = 3f;
    private Rigidbody2D characterRigidBody;
    public Animator anim;
    public Transform childSprite;
    public int playerNum;

    public PlayerInput playerInput;

    public bool pause = false;
    

    
    void Start()
    {
        characterRigidBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        deviceCheck();
    }

    
    void Update()
    {
        //disables controlls on pause
        if(pause == false){
            controlls();
            spriteRotation();
        } 

        if(moveHorizontal != 0 || moveVertical != 0){
            anim.SetBool("isMoving", true);
        } else{
            anim.SetBool("isMoving", false);
        }

        

    }

    private void FixedUpdate()
    {
       characterRigidBody.velocity = new UnityEngine.Vector2(moveHorizontal * movementSpeed, moveVertical * movementSpeed);
    }

    private void spriteRotation(){
        float angle = Mathf.Atan2(moveVertical, moveHorizontal)*Mathf.Rad2Deg+270;
        childSprite.transform.rotation =UnityEngine.Quaternion.Euler(0,0,angle);
    }

    //sets player devices to controllers if more than one controler is plugged in
    void deviceCheck(){
        if( InputSystem.devices.Count > 3){
            playerInput.SwitchCurrentControlScheme("Gamepad", Gamepad.all[playerInput.playerIndex]);
        }
    }

    
    //input handler
    private void controlls(){
        
        moveHorizontal = playerInput.actions["Move"].ReadValue<UnityEngine.Vector2>().x;
        moveVertical = playerInput.actions["Move"].ReadValue<UnityEngine.Vector2>().y;
        
    }

    public void setPlayerNum(int num){
        playerNum = num;
    }

    public void pauseGame(bool inputPause){
        pause = inputPause;
        Debug.Log(pause);
    }



}
