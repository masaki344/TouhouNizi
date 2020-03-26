using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC12 : MonoBehaviour
{
    //体力
    private int HP = 30;

    //横幅移動制限
    private float movableWideRange = 4.5f;
    //縦幅移動制限
    private float movableHeightRange = 5.5f;
    //射出角度間隔
    private float degree = 0.0f;
    //射出角度
    private float offsetDegree = 180.0f;
    //射出時間間隔
    private float shotSpan = 1.0f;
    //射出回数
    private int kaisuu = 2;
    //１回当たりの射出個数
    private int kosuu = 4;
    //ｘ軸の移動量
    private float x = 0;
    //ｙ軸の移動量
    private float y = 0;
    //フラグ
    private int flag = 0;
    //
    float min = 0.5f;
    float max = 0.5f;

    //bulletPrefabを入れる
    public GameObject bulletPrefab;
    //
    private GameObject[] bulletGameObject;

    //
    Vector3 center = new Vector3(-1.0f,3.0f, 0);
    Vector3 targetPos = new Vector3(-3.0f, 3.0f, 0);

    //
    private Animator FRAnimator;
    //
    GameObject ziki;

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

        //
        ziki = GameObject.FindGameObjectWithTag("Player");
        //
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
        transform.Translate(x, y, 0);

        //
        if (flag == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime);
        }

        if (flag == 2)
        {
            transform.RotateAround(center, Vector3.forward, Time.deltaTime * 30);
            transform.Rotate(0, 0, Time.deltaTime * -30);
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
        yield return new WaitForSeconds(2.4f);
        flag += 1;
        yield return new WaitForSeconds(3.0f);
        flag += 1;
        x = 0.02f;
        float index = Random.Range(min, max);
        yield return new WaitForSeconds(index);
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
        float dx = ziki.transform.position.x - transform.position.x;
        float dy = ziki.transform.position.y - transform.position.y;
        offsetDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg - 90;

        if (n <= this.kaisuu)
        {
            for (int a = (m - 1) * kosuu; a < m * kosuu; a++)
            {
                bulletGameObject[a].transform.position = this.transform.position;
                bulletGameObject[a].transform.rotation = Quaternion.Euler(0, 0, degree * a - degree * kosuu * (n - 1) + offsetDegree);
                bulletGameObject[a].SetActive(true);
                bulletGameObject[a].name = a.ToString();
            }
            m++;
        }
        //射出回数をカウント
        n++;
    }
}
