using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public GameObject loading;

    public GameObject sinPrefab;
    public GameObject xSinPrefab;
    public GameObject xCosPrefab;
    public GameObject lnPrefab;
    public GameObject exPrefab;

    public Transform[] parentObj; // 관리를 위한 임시 부모 오브젝트

    GameObject[] sin;
    GameObject[] xSin;
    GameObject[] xCos;
    GameObject[] ln;
    GameObject[] ex;

    GameObject[] targetPool; // 풀링할 타겟 설정

    

    

    void Awake()
    {
        if(instance != this)
            instance = this;

        sin = new GameObject[100];
        xSin = new GameObject[55];
        xCos = new GameObject[55];
        ln = new GameObject[55];
        ex = new GameObject[55];

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
        for (int i = 0; i < xSin.Length; i++)
        {
            xSin[i] = Instantiate(xSinPrefab);
            xSin[i].transform.SetParent(parentObj[1]);
            xSin[i].SetActive(false);
            //yield return new WaitForSeconds(0.001f);
        }
        for (int i = 0; i < xCos.Length; i++)
        {
            xCos[i] = Instantiate(xCosPrefab);
            xCos[i].transform.SetParent(parentObj[2]);
            xCos[i].SetActive(false);
            //yield return new WaitForSeconds(0.001f);
        }
        for (int i = 0; i < ln.Length; i++)
        {
            ln[i] = Instantiate(lnPrefab);
            ln[i].transform.SetParent(parentObj[3]);
            ln[i].SetActive(false);
            //yield return new WaitForSeconds(0.001f);
        }
        for (int i = 0; i < ex.Length; i++)
        {
            ex[i] = Instantiate(exPrefab);
            ex[i].transform.SetParent(parentObj[4]);
            ex[i].SetActive(false);
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
            case "sin":
                targetPool = sin;
                break;
            case "xSin" :
                targetPool = xSin;
                break;
            case "xCos":
                targetPool = xCos;
                break;
            case "ln":
                targetPool = ln;
                break;
            case "ex":
                targetPool = ex;
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
