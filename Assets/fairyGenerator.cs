using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairyGenerator : MonoBehaviour
{
    public GameObject BFSP;
    public GameObject RFSP1;
    public GameObject BFSP2;
    public GameObject RFSP3;
    public GameObject RFMP4;
    public GameObject RFSP5;
    public GameObject BFSP6;
    public GameObject RFMP7;
    public GameObject RFSP8;
    public GameObject BFSP9;
    public GameObject RFLP10;
    public GameObject BFLP11;
    public GameObject BFSP12;
    public GameObject RFSP13;
    public GameObject BFLP14;
    public GameObject RFLP15;
    public GameObject RFSP16;
    public GameObject BFSP17;
    public GameObject BFMP22;
    public GameObject RFMP23;
    public GameObject RFLP24;
    public GameObject BFMP25;
    public GameObject RFMP26;
    public GameObject RFLP27;
    public GameObject BFMP28;
    public GameObject RFMP29;
    public GameObject RFLP30;

    void Start()
    {
        StartCoroutine(Story());
    }

    void Update() 
    {

    }

    IEnumerator Story()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Fairy(BFSP, 8, 0.3f, 4.5f, 3.0f));
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(Fairy(RFSP1, 8, 0.3f, -4.5f, 3.0f));
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(Fairy(BFSP2, 8, 0.3f, 4.5f, 5.5f));
        StartCoroutine(Fairy(RFSP3, 8, 0.3f, -4.5f, 5.5f));
        yield return new WaitForSeconds(10.0f);
        StartCoroutine(Fairy(RFMP4, 1, 0, 2.0f, 5.5f));
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fairy(RFSP5, 10, 0.2f, -4.5f, 2.0f));
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fairy(BFSP6, 10, 0.2f, 4.5f, 1.0f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(RFMP7, 1, 0, -2.0f, 5.5f));
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fairy(RFSP8, 10, 0.2f, -4.5f, 2.0f));
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fairy(BFSP9, 10, 0.2f, 4.5f, 1.0f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(RFLP10, 1, 0, -2.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(BFLP11, 1, 0, 2.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(BFSP12, 6, 0.5f, -3.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(RFSP13, 6, 0.5f, 3.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(BFLP14, 1, 0, 2.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(RFLP15, 1, 0, -2.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(RFSP16, 6, 0.5f, 3.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy(BFSP17, 6, 0.5f, -3.0f, 5.5f));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fairy1(BFMP22, 8, 1.0f, -3.5f, 5.5f, 1.0f, 0));
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(Fairy1(RFMP23, 8, 1.0f, 3.5f, 5.5f, -1.0f, 0));
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(Fairy1(RFLP24, 8, 0.0f, -2.5f, 5.5f, 5.0f, 0.0f));
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(Fairy1(BFMP25, 8, 1.0f, -3.5f, 5.5f, 1.0f, 0));
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(Fairy1(RFMP26, 8, 1.0f, 3.5f, 5.5f, -1.0f, 0));
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(Fairy1(RFLP27, 8, 0.0f, -2.5f, 5.5f, 5.0f, 0.0f));
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(Fairy1(BFMP28, 8, 1.0f, -3.5f, 5.5f, 1.0f, 0));
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(Fairy1(RFMP29, 8, 1.0f, 3.5f, 5.5f, -1.0f, 0));
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(Fairy(RFLP30, 1, 0, 0, 5.5f));
    }

    IEnumerator Fairy(GameObject a, int kaisuu, float span, float x, float y)
    {
        for (int i = 0; i < kaisuu; i++)
        {
            GameObject fairy = Instantiate(a) as GameObject;
            fairy.transform.position = new Vector2(x, y);
            yield return new WaitForSeconds(span);
        }
    }

    IEnumerator Fairy1(GameObject a, int kaisuu, float span, float x, float y, float spanX, float spanY)
    {
        for (int i = 0; i < kaisuu; i++)
        {
            GameObject fairy = Instantiate(a) as GameObject;
            fairy.transform.position = new Vector2(x, y);
            x += spanX;
            y += spanY;
            yield return new WaitForSeconds(span);
        }
    }
}
