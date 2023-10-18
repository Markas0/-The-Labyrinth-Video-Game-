using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]

public class PlayerMove : MonoBehaviour
{
   
public float playerSpeed = 20f;
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
        CheckForHeadBob();

        camAnim.SetBool(name:"isWalking", isWalking);

    }


    void GetInput()
    {

           inputVector = new Vector3(x:Input.GetAxisRaw("Horizontal"), y:0f, z:Input.GetAxisRaw("Vertical")); 
           inputVector.Normalize();
           inputVector = transform.TransformDirection(inputVector);

           movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity); 

    }


    void MovePlayer()
    {

        myC.Move(motion: movementVector * Time.deltaTime);

    }


    void CheckForHeadBob()
    {
            if(myC.velocity.magnitude > 0.1f)
            {
                    isWalking = true;

            }
            else
            {
                    isWalking = false; 
            }

    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
