using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01Controller : MonoBehaviour
{
    public float times;//循环
    public float jishi = 3f;//计时器
    public Rigidbody2D rigi;
    public float speed;
    public int abs = 1;
    void Start()
    {
        times = jishi;
    }
    void Update()
    {
        times -= Time.deltaTime;//计时沙漏
        if (times<0)
        {
            abs = -abs;
            times = jishi;
        }
        if (abs!=0)
        {
            rigi.transform.localScale = new Vector3(abs,1,1);
        }
        Vector2 zy = rigi.position;
        zy.x = zy.x + Time.deltaTime * speed* abs;
        rigi.MovePosition(zy);
    }
}
