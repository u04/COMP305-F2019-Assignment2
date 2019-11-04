using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody;
    public float movementSpeed;
    public bool isFacingRight = true;
    public Transform lookAhead;
    public bool hasGroundAhead;
    public bool isGrounded;
    public bool isFacingLeft;
    public Transform groundTarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundTarget.position, 1 << LayerMask.NameToLayer("Ground"));
        hasGroundAhead = Physics2D.Linecast(transform.position, lookAhead.position, 1 << LayerMask.NameToLayer("Ground"));
        if (isGrounded)
        {
            if (isFacingRight)
            {
                enemyRigidBody.velocity = new Vector2(movementSpeed, 0.0f);
            }
            if (!isFacingRight)
            {
                enemyRigidBody.velocity = new Vector2(-movementSpeed, 0.0f);
            }
            if (!hasGroundAhead)
            {
                transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1.0f);
                isFacingRight = !isFacingRight;
            }

        }


        
        // if (!hasGroundAheadRight)
        // {
        //     transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1.0f);
        // }
        // if (!hasGroundAheadLeft)
        // {
        //     transform.localScale = new Vector3(transform.localScale.x, 1.0f, 1.0f);
        // }

    }
}
