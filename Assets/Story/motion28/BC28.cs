﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC28 : MonoBehaviour
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
        rb.velocity = this.transform.up * 2.0f;
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
