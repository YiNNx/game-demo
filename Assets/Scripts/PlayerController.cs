using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpForce = 6f;
    public Rigidbody2D rb;
    public Animator animator;
    bool jumpPress;
    int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
    }

    private void FixedUpdate() 
    {
        Move();
    }

    void Move()
    {
        float moveX=Input.GetAxisRaw("Horizontal");
        if(moveX!=0){
            transform.localScale = new Vector3(moveX,1,1);
            animator.SetInteger("running",1);
            Vector2 position = transform.position;
            position.x+=moveX * speed * Time.deltaTime;
            transform.position=position;
        }else{
            animator.SetInteger("running",0);

        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            animator.SetInteger("jumpforward",1);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }else{
            animator.SetInteger("jumpforward",0);

        }
    }

}
