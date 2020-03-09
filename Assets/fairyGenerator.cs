using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairyGenerator : MonoBehaviour
{
    public GameObject fairyPrefab;
    
    //最初の妖精の数
    private int count = 0;
    //妖精の数
    private int kaisuu = 1;
    //最初の時間
    private float delta = 0f;
    //時間間隔
    private float span = 1.0f;
    //ｘ座標
    private float x = 0f;
    //ｙ座標
    private float y = 4.0f;


    void Start()
    {

    }

    void Update()
    {
        //妖精がkaisuu匹以下なら
        if (this.count < this.kaisuu)
        {
            this.delta += Time.deltaTime;

            //span秒経ったら
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject fairy = Instantiate(fairyPrefab) as GameObject;
                fairy.transform.position = new Vector2(x, y);
                x += 1.0f;
                count++;
            }

        }
    }
}
