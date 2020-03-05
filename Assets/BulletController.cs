using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
        this.transform.Translate(0, 0.01f, 0);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player_reimu_0")
        {
            Destroy(this.gameObject);
        }
    }
}
