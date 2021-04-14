using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PatternManager : MonoBehaviour
{
    GameObject cTest;
    List<GameObject> circles;
    public int ballNum; // 공 개수(왼,오 중 한쪽만 체크)

    public delegate void sinBulletMove();
    public static event sinBulletMove sinAction;


    // Start is called before the first frame update
    void Start()
    {
        circles = new List<GameObject>();
        for (int i = 0; i <= ballNum; i++)
        {
            cTest = ObjectManager.instance.MakeObj("circle");
            cTest.transform.position = new Vector2((16.0f/ballNum * i) - 8.0f ,0);
            Sinbullet s = cTest.GetComponent<Sinbullet>();
            s.value = i;
            circles.Add(cTest);
        }
        
    }

    void Update() //임시 함수테스트코드
    {
        if (Input.GetKeyDown(KeyCode.A))
            Xsin();
    }

    void Xsin()
    {
        sinAction();
    }

    
}
