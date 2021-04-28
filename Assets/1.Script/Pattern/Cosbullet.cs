using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosbullet : BulletType
{

    float xJul;

    public override void MovePos()
    {
        if (gameObject.activeSelf)
            StartCoroutine(SmoothMove());
    }

    IEnumerator SmoothMove()
    {
        curPos = gameObject.transform.position;
        for (int i = 0; i <= 10; i++)
        {
            xJul = curPos.x + 8; // 도형에서 평행이동한 x값(화면 왼쪽이 원점)
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x, 0.25f * xJul * Mathf.Cos(xJul)), 0.1f * i);
            // y = x * sin(x)
            yield return new WaitForSeconds(0.05f);
        }
        curPos = new Vector2(xJul, gameObject.transform.position.y);
        yield return new WaitForSeconds((curPos.x) * 0.2f);
        LineSlide();
    }

    public override void LineSlide() //접선 패턴
    {
        float num = curPos.x + 1;
        float jupsunY = (0.25f * (Mathf.Cos(curPos.x) + -1*(curPos.x) * Mathf.Sin(curPos.x))) + (0.25f * (curPos.x) * Mathf.Cos(curPos.x));
        //접점을 (t,t cos(t))라 하고, 임의의 점의 x좌표를 t+1으로 두자.(점간의 벡터거리 구하기 위함)
        //원함수 : y=0.25*{(x+8) cos (x+8)}
        //접선 방정식 : y = 0.25*[{ sin(t+8) -(t+8)*cos(t+8)  } * (x-t) + {(t+8)*cos(t+8)}]
        Vector2 jupsunPos = new Vector2(num, jupsunY); // 접선을 지나는 한 점
        Vector2 dirVec = (jupsunPos - curPos).normalized;
        startPos = new Vector2(curPos.x - 8, curPos.y); // 현재 위치(smoothmove에서 평행이동되었음을 고려하여, -8을 하여 보정해줌)
        StartCoroutine(LineExpand(dirVec));
    }

}
