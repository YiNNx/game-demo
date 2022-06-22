using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpForce = 6f;
    public Rigidbody2D rb;
    public Animator animator;
    bool isJump;
    bool isMove;
    float move;
    int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
    
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
        }else{
            isJump=false;
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
        if (isJump)
        {
            animator.SetInteger("jumpforward",1);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }else{
            animator.SetInteger("jumpforward",0);
        }
    }

    void Anime(){

        if(move!=0){
            transform.localScale = new Vector3(move,1,1);
            animator.SetInteger("running",1);
        }else{
            animator.SetInteger("running",0);
        }

        if (isJump)
        {
            animator.SetInteger("jumpforward",1);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }else{
            animator.SetInteger("jumpforward",0);
        }

    }

}
