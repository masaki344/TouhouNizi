using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    //速度
    private float speed = 0.5f;
    //縦幅移動制限
    private float heightRange = 4.5f;

    void Start()
    {

    }
	
	void Update ()
    {
        //上方移動
        this.transform.Translate(0, this.speed, 0);

        //上まで行ったら消す
        if (this.transform.position.y > heightRange)
        {
            Destroy(this.gameObject);
        }
	}
}
