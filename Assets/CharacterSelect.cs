using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject reimuPrefab;
    public GameObject marisaPrefab;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Start ()
    {

	}

    void Update ()
    {
        
    }

    public void OnClick(int number)
    {
        SceneManager.LoadScene("GameScene");
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (number == 0)
            {
                GameObject reimu = Instantiate(reimuPrefab) as GameObject;
            }
            if (number == 1)
            {
                GameObject marisa = Instantiate(marisaPrefab) as GameObject;
            }
        }
    }
}
