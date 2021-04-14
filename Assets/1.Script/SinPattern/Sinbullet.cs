using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinbullet : MonoBehaviour
{
    public int value;
    void Start()
    {
        
    }

    void OnEnable()
    {
        PatternManager.sinAction += MovePos;
    }

    void MovePos()
    {
        if(gameObject.activeSelf)
            StartCoroutine(SmoothMove());
    }

    IEnumerator SmoothMove()
    {
        Vector2 curPos = gameObject.transform.position;
        for (int i = 0; i <= 10; i++)
        {
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x, 0.2f*value * Mathf.Sin(value)), 0.1f * i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
