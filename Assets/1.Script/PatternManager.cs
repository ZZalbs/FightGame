using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PatternManager : MonoBehaviour
{
    GameObject cTest;
    List<GameObject> circles;
    public int ballNum; // 공 개수

    public delegate void BulletMove();
    public static event BulletMove Action;


    // Start is called before the first frame update
    void Start()
    {
        circles = new List<GameObject>();
        StartCoroutine(SinBallmake());
    }

    IEnumerator SinBallmake()
    {
        //for (int i = 0; i <= ballNum; i++)
        //{
        //    cTest = ObjectManager.instance.MakeObj("sin");
        //    cTest.transform.position = new Vector2((Mathf.PI*5.0f / ballNum * i) - 8.0f, 0);
        //    circles.Add(cTest);
        //    yield return new WaitForSeconds(0.01f);
        //}
        //for (int i = 0; i <= ballNum; i++)
        //{
        //    cTest = ObjectManager.instance.MakeObj("cos");
        //    cTest.transform.position = new Vector2((Mathf.PI * 5.0f / ballNum * i) - 8.0f, 0);
        //    circles.Add(cTest);
        //    yield return new WaitForSeconds(0.01f);
        //}
        //for (int i = 0; i <= ballNum; i++)
        //{
        //    cTest = ObjectManager.instance.MakeObj("ln");
        //    cTest.transform.position = new Vector2((Mathf.PI * 5.0f / ballNum * i) - 8.0f, 0);
        //    circles.Add(cTest);
        //    yield return new WaitForSeconds(0.01f);
        //}
        for (int i = 0; i <= ballNum; i++)
        {
            cTest = ObjectManager.instance.MakeObj("ex");
            cTest.transform.position = new Vector2((Mathf.PI * 5.0f / ballNum * i) - 8.0f, 0);
            circles.Add(cTest);
            yield return new WaitForSeconds(0.01f);
        }
    }


    void Update() //임시 함수테스트코드
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Xsin();
        }
        //if (Input.GetKeyDown(KeyCode.B))
        //{

        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{

        //}
    }

    void Xsin()
    {
        Action();
    }


}
