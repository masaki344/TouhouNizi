using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC17 : MonoBehaviour
{
    //横幅移動制限
    private float movableWideRange = 4.5f;
    //縦幅移動制限
    private float movableHeightRange = 5.0f;

    public Rigidbody2D rb;
    //速さ
    private float speed = 1.0f;

    void Start()
    {
        int kosuu = 5;
        int n = 1;
        int accel = int.Parse(name);
        while (accel + 1 > kosuu * n)
        {
            n++;
        }
        accel -= kosuu * (n - 1);
        rb.velocity = this.transform.up * (speed + accel) * 0.5f;
    }

    void Update()
    {
        //画面外で消える
        if (movableWideRange < transform.position.x || -movableWideRange > transform.position.x ||
            movableHeightRange < transform.position.y || -movableHeightRange > transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
