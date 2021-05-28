using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinBullet : BulletType
{

    float xChange; // �����̵� x�� �־��ٰ�
    float yline; // y���� ���Ʒ��� �ٲ��ٶ�� ���� ������

    public override void MovePos()
    {
        if(gameObject.activeSelf)
            StartCoroutine(SmoothMove());
        yline = curPos.y;
        xChange = curPos.x + 8; // �������� �����̵��� x��(ȭ�� ������ ����)
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
