using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinbullet : BulletType
{
    public int incline; // ���� �����
    float xJul;
    float expandNum; // ���� õõ�� ������� ������� ��
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
            xJul = curPos.x+8; // �������� �����̵��� x��(ȭ�� ������ ����)
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x,  0.25f* xJul * Mathf.Sin(xJul)), 0.1f * i);
            // y = x * sin(x)
            yield return new WaitForSeconds(0.05f);
        }
        curPos = gameObject.transform.position;
        yield return new WaitForSeconds((curPos.x+8.0f)*0.2f);
        lineSlide();
    }

    public void lineSlide()
    {
        Debug.Log(curPos.x/Mathf.PI);
        float num = curPos.x + 1;
        float jupsunY = ( 0.25f*(Mathf.Sin(curPos.x+8)+(curPos.x+8)*Mathf.Cos(curPos.x+8)) ) + (0.25f* (curPos.x+8) * Mathf.Sin(curPos.x+8));
        //������ (t,t sin(t))�� �ϰ�, ������ ���� x��ǥ�� t+1���� ����.(������ ���ͰŸ� ���ϱ� ����)
        //���Լ� : y=(x-8) sin (x-8)
        //���� ������ : y = { sin(t+8) +(t+8)*cos(t+8)  } * (x-t) + {(t+8)*sin(t+8)}
        Vector2 jupsunPos = new Vector2(num, jupsunY); // ������ ������ �� ��
        Vector2 dirVec = (jupsunPos-curPos).normalized;
        LineDrawManager.instance.LineDraw(lr, curPos-dirVec*expandNum, curPos+dirVec*expandNum, 0.05f, 0.05f,new Color(255,255,255));
        StartCoroutine(LineExpand(dirVec));
    }

    IEnumerator LineExpand(Vector2 dirvec)
    {
        float xValue=0.0f; // �����Լ� ��� ����
        while (true)
        {
            xValue += 0.1f;
            expandNum = Mathf.Pow(xValue,2);
            yield return new WaitForSeconds(0.01f);
            LineDrawManager.instance.LineDraw(lr, curPos - dirvec * expandNum, curPos + dirvec * expandNum, 0.05f, 0.05f, new Color(255, 255, 255));
            if (-5.0f >= (curPos - dirvec * expandNum).x && 5.0f <= (curPos + dirvec * expandNum).x )
                break;
            if (-8.0f >= (curPos - dirvec * expandNum).y && 8.0f <= (curPos + dirvec * expandNum).y )
                break;
        }
    }

}
