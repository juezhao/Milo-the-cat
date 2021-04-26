﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    float HorizontalMove = 0f;

    bool jump = false;

    bool crouch = false;
    
    // Update is called once per frame
    void Update()
    {
        
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(HorizontalMove));
        
        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping",true);
        }

        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }
    }

    public void Onlanding ()
    {
        animator.SetBool("IsJumping",false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate ()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
