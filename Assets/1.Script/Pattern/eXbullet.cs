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
            xJul = curPos.x + 8; // �������� �����̵��� x��(ȭ�� ������ ����)
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

    public override void LineSlide() //���� ����
    {
        float num = curPos.x + 1;
        float jupsunY;
        jupsunY = 0.001f*((Mathf.Exp(curPos.x)-4) + (Mathf.Exp(num))-4);
        //������ (t e^(t)-4)�� �ϰ�, ������ ���� x��ǥ�� t+1���� ����.(������ ���ͰŸ� ���ϱ� ����)
        //���Լ� : y=0.25*{e^ (x+8)-4}
        //���� ������ : y = 0.25*[{ e^(t+8)-4} * (x-t) + {e^(t+8)-4}]
        Vector2 jupsunPos = new Vector2(num, jupsunY); // ������ ������ �� ��
        Vector2 dirVec = (jupsunPos - curPos).normalized;
        startPos = new Vector2(curPos.x - 8, curPos.y+4); // ���� ��ġ(smoothmove���� �����̵��Ǿ����� ����Ͽ�, -8�� �Ͽ� ��������)
        StartCoroutine(LineExpand(dirVec));
    }

}
