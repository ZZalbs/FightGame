using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinbullet : BulletType
{
    public int incline; // 기울기 적어보자
    float xJul;
    Vector2 curPos,nextPos;
    LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    public override void MovePos()
    {
        if(gameObject.activeSelf)
            StartCoroutine(SmoothMove());
    }

    IEnumerator SmoothMove()
    {
        curPos = gameObject.transform.position;
        for (int i = 0; i <= 10; i++)
        {
            xJul = curPos.x+8; // x값(화면 왼쪽이 원점)
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x, 0.25f * xJul * Mathf.Sin(xJul)), 0.1f * i);
            // y = x * sin(x)
            yield return new WaitForSeconds(0.05f);
        }
        curPos = gameObject.transform.position;
        lineSlide();
    }

    public void lineSlide()
    {
        //StartCoroutine(LineExpand());
        float num = curPos.x + 1;
        float jupsunY = ((Mathf.Sin(curPos.x) + (curPos.x) * Mathf.Cos(curPos.x))) + (curPos.x * Mathf.Sin(curPos.x));
        //접점을 (t,t sin(t))라 하고, 임의의 점의 x좌표를 t+1으로 두자.(점간의 벡터거리 구하기 위함)
        //접선 방정식 : y = (t*cos(t)+sin(t)) * (x-t) + t*sin(t)
        Vector2 jupsunPos = new Vector2(num, jupsunY); // 접선을 지나는 한 점
        Vector2 normalVec = (jupsunPos-curPos).normalized;
        LineDrawManager.instance.LineDraw(lr, normalVec * 10.0f, normalVec * 10.0f, 0.1f, 0.1f);
        //LineDrawManager.instance.LineDraw(lr, curPos-normalVec*10, curPos+normalVec*10, 0.1f, 0.1f);

    }

    //IEnumerator LineExpand()
    //{
    //    float xPos2 = curPos.x;
    //    for (int i=0;i<10;i++)
    //    {
    //        Vector2 normalVec = curPos - ;
    //        LineDrawManager.instance.LineDraw(lr, curPos, nextPos, 0.1f, 0.1f);
    //        xPos2++;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}
}
