using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]

public class PlayerMove : MonoBehaviour
{
   
public float playerSpeed = 20f;
public float momentumDamping = 5f; 
private CharacterController myC;
public Animator camAnim;
private bool isWalking; 
private Vector3 inputVector;
private Vector3 movementVector;
private float myGravity = -10f;



    void Start()
    {
        
    myC = GetComponent<CharacterController>(); 

    }

    
    void Update()
    {
        
        GetInput();
        MovePlayer();


        camAnim.SetBool(name:"isWalking", isWalking);

    }


    void GetInput()
    {
if(Input.GetKey(KeyCode.W)||
   Input.GetKey(KeyCode.S)||
   Input.GetKey(KeyCode.A)||
   Input.GetKey(KeyCode.D)){

           inputVector = new Vector3(x:Input.GetAxisRaw("Horizontal"), y:0f, z:Input.GetAxisRaw("Vertical")); 
           inputVector.Normalize();
           inputVector = transform.TransformDirection(inputVector);

            isWalking = true;

   }
   else 
   {
           inputVector = Vector3.LerpUnclamped(a:inputVector, b:Vector3.zero, t:momentumDamping * Time.deltaTime); 

           isWalking = false; 
   }

           movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity); 

    }


    void MovePlayer()
    {

        myC.Move(motion: movementVector * Time.deltaTime);

    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
