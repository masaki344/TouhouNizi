using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject reimuPrefab;
    public GameObject marisaPrefab;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void OnClick(int number)
    {
        if (number == 0)
        {
            GameObject reimu = Instantiate(reimuPrefab) as GameObject;
        }
        if (number == 1)
        {
            GameObject marisa = Instantiate(marisaPrefab) as GameObject;
        }
        SceneManager.LoadScene("GameScene");
    }
}
