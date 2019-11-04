using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.UI;
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
    public AudioSource coinSound;
    public GameObject lable;
    [Header("Scoreboard")]
    [SerializeField]
    private int _score;
    public Text scoreLable;
  

    void Start()
    {
        playerAnimState = PlayerAnimState.IDLE;
        isGrounded = false;
        lable = GameObject.Find("TextOfCan");
       

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
  
    void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == "Coin")
            {
                // update socore
                coinSound.Play();
                Destroy(other.gameObject);
                Debug.Log("I hit a coin");
                _score = _score + 1;
                Debug.Log($"my score is {_score}");
                
                scoreLable.text = $"score: {_score}";

               


            }
        }
}
