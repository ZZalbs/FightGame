using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eXbullet : BulletType
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
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x, 0.001f * Mathf.Exp(xJul)-4), 0.1f * i);
            if ((0.001f * Mathf.Exp(xJul) - 4) > 5)
                gameObject.SetActive(false);
            // y = e^(x)
            yield return new WaitForSeconds(0.05f);
        }
        curPos = new Vector2(xJul, gameObject.transform.position.y);
        yield return new WaitForSeconds((curPos.x) * 0.2f);
        LineSlide();
    }

    public override void LineSlide() //접선 패턴
    {
        float num = curPos.x + 1;
        float jupsunY;
        jupsunY = 0.001f*((Mathf.Exp(curPos.x)-4) + (Mathf.Exp(num))-4);
        //접점을 (t e^(t)-4)라 하고, 임의의 점의 x좌표를 t+1으로 두자.(점간의 벡터거리 구하기 위함)
        //원함수 : y=0.25*{e^ (x+8)-4}
        //접선 방정식 : y = 0.25*[{ e^(t+8)-4} * (x-t) + {e^(t+8)-4}]
        Vector2 jupsunPos = new Vector2(num, jupsunY); // 접선을 지나는 한 점
        Vector2 dirVec = (jupsunPos - curPos).normalized;
        startPos = new Vector2(curPos.x - 8, curPos.y+4); // 현재 위치(smoothmove에서 평행이동되었음을 고려하여, -8을 하여 보정해줌)
        StartCoroutine(LineExpand(dirVec));
    }

}
