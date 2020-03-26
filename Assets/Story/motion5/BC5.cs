using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC5 : MonoBehaviour
{ 
    //横幅移動制限
    private float movableWideRange = 4.5f;
    //縦幅移動制限
    private float movableHeightRange = 5.0f;
    //速さ
    private float speed = 4.0f;

    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = this.transform.up * speed;
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
