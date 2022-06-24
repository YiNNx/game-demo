
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpForce = 6f;
    public Rigidbody2D rb;
    public Collider2D coll;
    public Transform groundCheck;
    public LayerMask grounder;
    public Animator animator;
    bool isJump;
    bool onGround;
    bool isMove;
    float move;
    public int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        jumpCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        getStatus();
        Jump();
    }

    void getStatus()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJump=true;
            jumpCount+=1;
        }else{
            isJump=false;
        }

        onGround=Physics2D.OverlapCircle(groundCheck.position, 0.03f, grounder);

        if(onGround){
            jumpCount=0;
        }

        move=Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() 
    {
        Move();
        Anime();
    }

    void Move()
    {
        rb.velocity=new Vector2(speed*move,rb.velocity.y);
    }

    void Jump()
    {
        if (isJump&&jumpCount<=1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }else{
        }
    }

    void Anime(){

        if(move!=0){
            transform.localScale = new Vector3(move,1,1);
            animator.SetInteger("running",1);
        }else{
            animator.SetInteger("running",0);
        }

        if (isJump&&jumpCount<=2)
        {
            animator.SetInteger("jumpforward",1);
        }else{
            animator.SetInteger("jumpforward",0);
        }

    }

}
