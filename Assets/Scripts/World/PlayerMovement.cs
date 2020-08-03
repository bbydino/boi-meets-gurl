using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer sprite;

    public Transform player;
    public Rigidbody2D rbd;
    public BoxCollider2D myCollider;
    public EdgeCollider2D edgeCol;

    public Vector2 speed = new Vector2(3, 0);
    public Vector2 jump = new Vector2(0, 5);
    public Vector2 colliderSize;

    bool isJumping = false;
    bool isCrouching = false;
    bool changeCol = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        player = GetComponent<Transform>();
        rbd = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        edgeCol = GetComponent<EdgeCollider2D>();
        colliderSize = new Vector2(myCollider.size.x, myCollider.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal movement
        float x = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(speed.x * x, rbd.velocity.y);

        // collider
        if (!isCrouching)
        {
            myCollider.size = colliderSize;
            myCollider.offset = new Vector2(0f, 0f);
            edgeCol.offset = new Vector2(0, 0);
            changeCol = false;
        }

        // animations
        animator.SetFloat("Speed", Math.Abs(rbd.velocity.x));
        animator.SetBool("IsCrouching", isCrouching);
        
        // jump
        if (!isJumping && !isCrouching && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            isJumping = true;
            rbd.AddForce(jump, ForceMode2D.Impulse);
        }

        // sprite facing direction
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) 
            transform.rotation = Quaternion.Euler(0, 180, 0); // sprite.flipX = true;

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            transform.rotation = Quaternion.Euler(0, 0, 0); // sprite.flipX = false;

        // crouch
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // make collider smaller
            isCrouching = true;
            if (!isJumping && !changeCol)
            {
                makeColliderSmaller();
            }
        }
        else isCrouching = false;

        // atk
        if (Input.GetKeyDown(KeyCode.Space)) animator.SetTrigger("Attack");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.otherCollider == edgeCol);

        if (col.otherCollider == edgeCol)
        {
            isCrouching = true;
            animator.SetBool("IsCrouching", isCrouching);
            makeColliderSmaller();
        }

        if (col.collider.name == "Ground")
        {
            isJumping = false;
            animator.SetBool("IsJumping", isJumping);
            rbd.velocity = Vector2.zero;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.name == "Ground")
        {
            isJumping = true;
            animator.SetBool("IsJumping", isJumping);
        }
    }

/*    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.name == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }
    }
*/


    void makeColliderSmaller()
    {
        double boxY = myCollider.size.y;
        myCollider.size = new Vector2(myCollider.size.x, (float)(boxY / 2));
        myCollider.offset = new Vector2(0f, -(float)(boxY / 4));
        edgeCol.offset = new Vector2(0f, -(float)(boxY / 2));
        changeCol = true;
    }
}
