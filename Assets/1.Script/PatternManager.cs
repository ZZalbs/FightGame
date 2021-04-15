using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PatternManager : MonoBehaviour
{
    GameObject cTest;
    List<GameObject> circles;
    public int ballNum; // �� ����(��,�� �� ���ʸ� üũ)

    public delegate void sinBulletMove();
    public static event sinBulletMove sinAction;


    // Start is called before the first frame update
    void Start()
    {
        circles = new List<GameObject>();
        StartCoroutine(Ballmake());
    }

    IEnumerator Ballmake()
    {
        for (int i = 0; i <= ballNum; i++)
        {
            cTest = ObjectManager.instance.MakeObj("circle");
            cTest.transform.position = new Vector2((16.0f / ballNum * i) - 8.0f, 0);
            circles.Add(cTest);
            yield return new WaitForSeconds(0.01f);
        }
    }


    void Update() //�ӽ� �Լ��׽�Ʈ�ڵ�
    {
        if (Input.GetKeyDown(KeyCode.A))
            Xsin();
    }

    void Xsin()
    {
        sinAction();
    }


}
