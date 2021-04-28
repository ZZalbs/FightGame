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
            xJul = curPos.x + 8; // �������� �����̵��� x��(ȭ�� ������ ����)
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x, 0.25f * xJul * Mathf.Cos(xJul)), 0.1f * i);
            // y = x * sin(x)
            yield return new WaitForSeconds(0.05f);
        }
        curPos = new Vector2(xJul, gameObject.transform.position.y);
        yield return new WaitForSeconds((curPos.x) * 0.2f);
        LineSlide();
    }

    public override void LineSlide() //���� ����
    {
        float num = curPos.x + 1;
        float jupsunY = (0.25f * (Mathf.Cos(curPos.x) + -1*(curPos.x) * Mathf.Sin(curPos.x))) + (0.25f * (curPos.x) * Mathf.Cos(curPos.x));
        //������ (t,t cos(t))�� �ϰ�, ������ ���� x��ǥ�� t+1���� ����.(������ ���ͰŸ� ���ϱ� ����)
        //���Լ� : y=0.25*{(x+8) cos (x+8)}
        //���� ������ : y = 0.25*[{ sin(t+8) -(t+8)*cos(t+8)  } * (x-t) + {(t+8)*cos(t+8)}]
        Vector2 jupsunPos = new Vector2(num, jupsunY); // ������ ������ �� ��
        Vector2 dirVec = (jupsunPos - curPos).normalized;
        startPos = new Vector2(curPos.x - 8, curPos.y); // ���� ��ġ(smoothmove���� �����̵��Ǿ����� ����Ͽ�, -8�� �Ͽ� ��������)
        StartCoroutine(LineExpand(dirVec));
    }

}
