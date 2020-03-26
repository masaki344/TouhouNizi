using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC7 : MonoBehaviour
{
    //体力
    private int HP = 150;

    //横幅移動制限
    private float movableWideRange = 4.5f;
    //縦幅移動制限
    private float movableHeightRange = 5.5f;
    //射出角度間隔
    private float degree = 10.0f;
    //射出角度
    private float offsetDegree = 180.0f;
    //射出時間間隔
    private float shotSpan = 3.0f;
    //射出回数
    private int kaisuu = 4;
    //１回当たりの射出個数
    private int kosuu = 36;
    //ｘ軸の移動量
    private float x = 0;
    //ｙ軸の移動量
    private float y = 0;
    //フラグ
    private int flag = 0;
    //ランダム
    private float index;

    //bulletPrefabを入れる
    public GameObject bulletPrefab;
    //
    private GameObject[] bulletGameObject;

    Vector3 targetPos = new Vector3(-2.0f, 3.0f, 0);
    float stopTime = 1.0f;
    Vector3 targetPos1 = new Vector3(-2.0f, -11.0f, 0);
    float moveTime = 10.0f;
    Vector3 velocity = new Vector3(0, 0, 0);

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
            for (int a = 0; a <= kaisuu * kosuu - 1; a++)
            {
                Destroy(bulletGameObject[a]);
            }
            Destroy(this.gameObject);
        }

        //画面外で消える
        if (movableWideRange < transform.position.x || -movableWideRange > transform.position.x ||
            movableHeightRange < transform.position.y || -movableHeightRange > transform.position.y)
        {
            for (int a = 0; a <= kaisuu * kosuu - 1; a++)
            {
                Destroy(bulletGameObject[a]);
            }
            Destroy(this.gameObject);
        }

        //
        if (flag == 1)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, stopTime);
        }

        if (flag == 2)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos1, ref velocity, moveTime);
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
        //
        flag += 1;
        yield return new WaitForSeconds(5.0f);
        Shot();
        flag += 1;
        //kaisuu以下なら
        for (int a = 0; a < kaisuu; a++)
        {
            //shotSpan秒間隔で射出
            Shot();
            yield return new WaitForSeconds(shotSpan);
        }
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
