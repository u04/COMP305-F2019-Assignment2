﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public PlayerAnimState playerAnimState;
    public Animator playerAnimator;
    public SpriteRenderer playerSpriteRenderer;
    public Rigidbody2D playerRigidbody2D;
    public float moveForce;
    public float jumpForce;
    public bool isGrounded;
    public Transform groundTarget;
    void Start()
    {
        playerAnimState = PlayerAnimState.IDLE;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundTarget.position, 1 << LayerMask.NameToLayer("Ground"));
        //idle state
        if (Input.GetAxis("Horizontal") == 0)
        {
            playerAnimState = PlayerAnimState.IDLE;
            playerAnimator.SetInteger("AnimState", (int) PlayerAnimState.IDLE);
        }
        //move right
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnimState = PlayerAnimState.RUN;
            playerAnimator.SetInteger("AnimState", (int) PlayerAnimState.RUN);
            playerSpriteRenderer.flipX = false;
            playerRigidbody2D.AddForce(Vector2.right * moveForce);
        }
        //move left
        if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnimState = PlayerAnimState.RUN;
            playerAnimator.SetInteger("AnimState", (int) PlayerAnimState.RUN);
            playerSpriteRenderer.flipX = true;
            playerRigidbody2D.AddForce(Vector2.left * moveForce);
        }
        //jump
        if ((Input.GetAxis("Jump") > 0) && (isGrounded))
        {
            playerAnimState = PlayerAnimState.JUMP;
            playerAnimator.SetInteger("AnimState", (int) PlayerAnimState.JUMP);
            playerRigidbody2D.AddForce(Vector2.up * jumpForce);
            isGrounded = true;
        }

    }
}
