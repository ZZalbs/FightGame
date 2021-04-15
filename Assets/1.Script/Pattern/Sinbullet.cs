using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinbullet : BulletType
{
    public int incline; // ���� �����
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
            xJul = curPos.x+8; // x��(ȭ�� ������ ����)
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
        //������ (t,t sin(t))�� �ϰ�, ������ ���� x��ǥ�� t+1���� ����.(������ ���ͰŸ� ���ϱ� ����)
        //���� ������ : y = (t*cos(t)+sin(t)) * (x-t) + t*sin(t)
        Vector2 jupsunPos = new Vector2(num, jupsunY); // ������ ������ �� ��
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
