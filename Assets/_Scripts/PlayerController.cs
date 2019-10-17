using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public PlayerAnimState playerAnimState;
    public Animator playerAnimator;
    public SpriteRenderer playerSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimState = PlayerAnimState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        //move left
        if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnimState = PlayerAnimState.RUN;
            playerAnimator.SetInteger("AnimState", (int) PlayerAnimState.RUN);
            playerSpriteRenderer.flipX = true;
        }
        //jump
        if (Input.GetAxis("Jump") > 0)
        {
            playerAnimState = PlayerAnimState.JUMP;
            playerAnimator.SetInteger("AnimState", (int) PlayerAnimState.JUMP);
        }

    }
}
