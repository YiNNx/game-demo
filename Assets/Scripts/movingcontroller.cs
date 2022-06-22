
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingcontroller : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
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

}

 