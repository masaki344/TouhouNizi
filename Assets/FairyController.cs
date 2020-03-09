using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyController : MonoBehaviour
{
    //体力
    private int HP = 100;

    //射出回数計測用の変数１（生成用）
    private int count1 = 1;
    //射出回数計測用の変数２
    private int count2 = 0;
    //射出回数計測用の変数３（射出用）
    private int count3 = 1;
    //射出角度間隔
    private float degree = 10.0f;
    //射出角度
    private float offsetDegree = 180.0f;
    //射出時間間隔
    private float shotSpan = 1.0f;
    //動く時間
    private float moveTime = 3.0f;
    //射出回数
    private int kaisuu = 4;
    //１回当たりの射出個数
    private int kosuu = 36;
    //ｘ軸の移動量
    private float x = 0;
    //ｙ軸の移動量
    private float y = -0.01f;

    //bulletPrefabを入れる
    public GameObject bulletPrefab;
    //
    private GameObject[] bulletGameObject;

    void Start ()
    {
        //個数を決める
        bulletGameObject = new GameObject[kosuu * kaisuu];

        //n-way弾を生成
        for (int a = 0; a < kosuu * kaisuu; a++)
        {
            bulletGameObject[a] = Instantiate(bulletPrefab) as GameObject;
            bulletGameObject[a].transform.rotation = Quaternion.Euler(0, 0, degree * a - degree * kosuu * (count1 - 1) + offsetDegree);
            bulletGameObject[a].SetActive(false);
            //生成回数をカウント
            if (a >= count1 * kosuu - 1)
            {
                count1++;
            }
        }
        StartCoroutine("Move");
    }
	
	void Update ()
    {
        //体力０で消える
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(x, y, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ショットにぶつかったら体力が１減る
        if (collision.name == "Shot1_0Prefab(Clone)")
        {
            HP -= 1;
        }
    }
    
    IEnumerator Move()
    {
        //moveTime秒動く
        yield return new WaitForSeconds(moveTime);
        //移動停止
        y = 0;
        //kaisuu以下なら
        for(int a = 0; a < kaisuu; a++)
        {
            //shotSpan秒間隔で射出
            Shot();
            yield return new WaitForSeconds(shotSpan);
        }
        //また動く
        y = -0.01f;
    }

    void Shot()
    {
        //射出回数をカウント
        this.count2++;

        if (this.count2 <= this.kaisuu)
        {
            for (int a = (count3 - 1) * kosuu; a < count3 * kosuu; a++)
            {
                bulletGameObject[a].transform.position = this.transform.position;
                bulletGameObject[a].SetActive(true);
            }
            count3++;
        }
    }
}

