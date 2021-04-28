using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public GameObject loading;

    public GameObject sinPrefab;
    public GameObject cosPrefab;

    public Transform[] parentObj; // 관리를 위한 임시 부모 오브젝트

    GameObject[] sin;
    GameObject[] cos;

    GameObject[] targetPool; // 풀링할 타겟 설정

    

    

    void Awake()
    {
        if(instance != this)
            instance = this;

        sin = new GameObject[55];
        cos = new GameObject[55];

        StartCoroutine("Generate");
        DontDestroyOnLoad(gameObject);
    }


    IEnumerator Generate()
    {
        loading.SetActive(true);
        Time.timeScale = 0.0f;
        for (int i = 0; i < sin.Length; i++)
        {
            sin[i] = Instantiate(sinPrefab);
            sin[i].transform.SetParent(parentObj[0]);
            sin[i].SetActive(false);
            //yield return new WaitForSeconds(0.001f);
        }
        for (int i = 0; i < cos.Length; i++)
        {
            cos[i] = Instantiate(cosPrefab);
            cos[i].transform.SetParent(parentObj[1]);
            cos[i].SetActive(false);
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
            case "sin" :
                targetPool = sin;
                break;
            case "cos":
                targetPool = cos;
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
