using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZikiController : MonoBehaviour
{
    //移動速度（高速）
    private float highSpeed = 0.08f;
    //移動速度（低速）
    private float lowSpeed = 0.05f;
    //横幅移動制限
    private float movableWideRange = 4.0f;
    //縦幅移動制限
    private float movableHeightRange = 4.5f;
    //shotPrefabを入れる
    public GameObject shotPrefab;
    //左右のショットの間隔
    private float shotSpace = 0.1f;
    //
    private Animator reimuAnimator;

	void Start ()
    {
        this.reimuAnimator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        //初期化
        Move(0, 0, false, false);
        //右方移動
        if (Input.GetKey(KeyCode.RightArrow) && this.movableWideRange > this.transform.position.x)
        {
            Move(1, 0, true, false);
        }
        //左方移動
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableWideRange < this.transform.position.x)
        {
            Move(-1, 0, false, true);
        }
        //上方移動
        if (Input.GetKey(KeyCode.UpArrow) && this.movableHeightRange > this.transform.position.y)
        {
            Move(0, 1, false, false);
        }
        //下方移動
        if (Input.GetKey(KeyCode.DownArrow) && -this.movableHeightRange < this.transform.position.y)
        {
            Move(0, -1, false, false);
        }

        //ショット
        if (Input.GetKey(KeyCode.Z))
        {
            //右ショットの生成
            GameObject rightShot = Instantiate(shotPrefab) as GameObject;
            rightShot.transform.position = new Vector2(this.transform.position.x + shotSpace, this.transform.position.y);
            //左ショットの生成
            GameObject leftShot = Instantiate(shotPrefab) as GameObject;
            leftShot.transform.position = new Vector2(this.transform.position.x - shotSpace, this.transform.position.y);
        }
    }

    void Move(float x, float y, bool r, bool l)
    {
        //低速
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(this.lowSpeed * x, this.lowSpeed * y, 0);
        }
        //高速
        else
        {
            this.transform.Translate(this.highSpeed * x, this.highSpeed * y, 0);
        }
        //アニメーション
        reimuAnimator.SetBool("RightBool", r);
        reimuAnimator.SetBool("LeftBool", l);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
