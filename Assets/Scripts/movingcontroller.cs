
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingcontroller : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    private int i;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
        i = 1;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,movePos[i].position,speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,movePos[i].position) < 0.1f)
        {
            if (waitTime < 0.0f)
            {
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }

                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //将movingPlateform作为player的父对象
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //将movingPlateform作为player的父对象
            other.gameObject.transform.parent = playerTransform;
        }
    }
}

 