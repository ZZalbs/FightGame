using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public GameObject loading;

    public GameObject circlePrefab;           

    GameObject[] circle;

    GameObject[] targetPool; // 풀링할 타겟 설정

    

    void Awake()
    {
        if(instance != this)
            instance = this;

        circle = new GameObject[55];

        StartCoroutine("Generate");
        DontDestroyOnLoad(gameObject);
    }


    IEnumerator Generate()
    {
        loading.SetActive(true);
        Time.timeScale = 0.0f;
        for (int i = 0; i < circle.Length; i++)
        {
            circle[i] = Instantiate(circlePrefab);
            circle[i].SetActive(false);
            //yield return new WaitForSeconds(0.001f);
        }
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.001f);
        loading.SetActive(false);
    }


    public GameObject MakeObj(string type)
    {
        switch(type)
        {
            case "circle" :
                targetPool = circle;
                break;
        }
        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }
        return null;
    }

    


}
