using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyController : MonoBehaviour
{
    //体力
    private int HP = 100;
    //最初の時間
    private float delta = 0;
    //最初の移動停止時間
    private float stopDelta = 0;
    //時間間隔
    private float span = 1.0f;
    //bulletPrefabを入れる
    public GameObject bulletPrefab;
    //角度間隔
    private float rad = 10.0f;
    //射出回数
    private int kaisuu = 1;
    //最初の回数
    private int count = 0;
    //移動停止時間
    private float stopSpan = 2.0f;

    void Start ()
    {
        
    }
	
	void Update ()
    {
        //体力０で消える
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }

        this.delta += Time.deltaTime;
        
        //span秒経ったら
        if (this.delta > this.span)
        {
            this.stopDelta += Time.deltaTime;
            
            //stopDelta秒経ったら
            if (this.stopDelta > this.stopSpan)
            {
                //初期化
                this.delta = 0;
                this.stopDelta = 0;

                //射出回数をカウント
                this.count++;

                //射出回数を超えないうちは
                if (this.count <= this.kaisuu)
                {
                    //n-way弾を射出
                    for (float a = 0; a < 360; a += this.rad)
                    {
                        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                        bullet.transform.position = this.transform.position;
                        bullet.transform.rotation = Quaternion.Euler(0, 0, this.rad * a);
                    }
                }
            }
        }
        //span秒経たなかったら
        else
        {
            //移動
            this.transform.Translate(0, -0.01f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ショットにぶつかったら体力が１減る
        if (collision.name == "Shot1_0Prefab(Clone)")
        {
            HP -= 1;
        }
    }
}

