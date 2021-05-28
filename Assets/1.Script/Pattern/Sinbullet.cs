using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinBullet : BulletType
{

    float xChange; // 평행이동 x값 넣어줄것
    float yline; // y축을 위아래로 바꿔줄라고 만든 기준축

    public override void MovePos()
    {
        if(gameObject.activeSelf)
            StartCoroutine(SmoothMove());
        yline = curPos.y;
        xChange = curPos.x + 8; // 도형에서 평행이동한 x값(화면 왼쪽이 원점)
    }

    IEnumerator SmoothMove()
    {
        curPos = gameObject.transform.position;
        
        for (int i = 0; i <= 20; i++)
        {
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x,  Mathf.Sin(xChange)+yline), 0.05f * i);
            // y = x * sin(x)
            yield return new WaitForSeconds(0.05f);
        }
        //curPos = new Vector2(xChange, gameObject.transform.position.y);
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(ChangetoCos());
    }

    IEnumerator ChangetoCos()
    {
        curPos = gameObject.transform.position;
        for (int i = 0; i <= 20; i++)
        {
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x, (-1)*Mathf.Sin(xChange)+yline), 0.05f * i);
            // y = cos(x)
            yield return new WaitForSeconds(0.05f);
        }
        //curPos = new Vector2(xChange, gameObject.transform.position.y);
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(SmoothMove());
    }
}
