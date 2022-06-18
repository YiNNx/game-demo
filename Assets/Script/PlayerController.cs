using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpForce = 6f;
    private Rigidbody2D rb;
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
        Vector2 position = transform.position;
        position.x+=moveX * speed * Time.deltaTime;
        transform.position=position;

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
        Vector2 position = transform.position;
        position.y+= 0.4f;
        transform.position=position;
        }
    }

}
