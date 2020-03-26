using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC1 : MonoBehaviour
{
    //体力
    private int HP = 20;

    //横幅移動制限
    private float movableWideRange = 4.5f;
    //縦幅移動制限
    private float movableHeightRange = 5.5f;
    //射出角度間隔
    private float degree = 10.0f;
    //射出角度
    private float offsetDegree = 180.0f;
    //射出時間間隔
    private float shotSpan = 1.0f;
    //射出回数
    private int kaisuu = 0;
    //１回当たりの射出個数
    private int kosuu = 0;
    //ｘ軸の移動量
    private float x;
    //ｙ軸の移動量
    private float y;
    //
    private float min = 3.0f;
    //
    private float max = 0.5f;
    //フラグ
    private int flag = 0;
    //ランダム
    private float index;

    //bulletPrefabを入れる
    public GameObject bulletPrefab;
    //
    private GameObject[] bulletGameObject;

    //
    private Animator FRAnimator;

    void Start()
    {
        //
        FRAnimator = GetComponent<Animator>();

        //個数を決める
        bulletGameObject = new GameObject[kosuu * kaisuu];

        //n-way弾を生成
        int n = 1;
        for (int a = 0; a < kosuu * kaisuu; a++)
        {
            bulletGameObject[a] = Instantiate(bulletPrefab) as GameObject;
            bulletGameObject[a].transform.rotation = Quaternion.Euler(0, 0, degree * a - degree * kosuu * (n - 1) + offsetDegree);
            bulletGameObject[a].SetActive(false);
            //生成回数をカウント
            if (a >= n * kosuu - 1)
            {
                n++;
            }
        }

        StartCoroutine("Move");
    }

    void Update()
    {
        //体力０で消える
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }

        //画面外で消える
        if (movableWideRange < transform.position.x || -movableWideRange > transform.position.x ||
            movableHeightRange < transform.position.y || -movableHeightRange > transform.position.y)
        {
            Destroy(this.gameObject);
        }

        //移動
        transform.Translate(x, y, 0);

        //下へ加速
        if (flag == 1)
        {
            x = 0.01f * index;
            y -= 0.0005f;
        }

        //
        FRAnimator.SetFloat("RightFloat", x);
        FRAnimator.SetFloat("LeftFloat", x);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ショットにぶつかったら体力が１減る
        if (collision.tag == "Shot")
        {
            HP -= 1;
        }
    }

    IEnumerator Move()
    {
        //kaisuu以下なら
        for (int a = 0; a < kaisuu; a++)
        {
            //shotSpan秒間隔で射出
            Shot();
            yield return new WaitForSeconds(shotSpan);
        }
        //左右バラバラに
        index = Random.Range(max, min);
        //また動く
        flag += 1;
    }

    int n = 1;
    int m = 1;
    void Shot()
    {
        if (n <= this.kaisuu)
        {
            for (int a = (m - 1) * kosuu; a < m * kosuu; a++)
            {
                bulletGameObject[a].transform.position = this.transform.position;
                bulletGameObject[a].SetActive(true);
            }
            m++;
        }
        //射出回数をカウント
        n++;
    }
}
