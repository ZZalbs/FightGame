using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lnbullet : BulletType
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
            if (xJul == 0)// ln0 = -���� �� ���̽� ����
                gameObject.SetActive(false);
            gameObject.transform.position = Vector2.Lerp(curPos, new Vector2(curPos.x, 1.5f * Mathf.Log(xJul)), 0.1f * i);
            // y = ln(x)
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
        jupsunY = (1.5f * (1 / (curPos.x))) + (1.5f * Mathf.Log(num));
        //������ (t,t cos(t))�� �ϰ�, ������ ���� x��ǥ�� t+1���� ����.(������ ���ͰŸ� ���ϱ� ����)
        //���Լ� : y=1.5*{(x+8) ln (x+8)}
        //���� ������ : y = 1.5*[{ 1/(t+8)} * (x-t) + {(t+8)}]
        Vector2 jupsunPos = new Vector2(num, jupsunY); // ������ ������ �� ��
        Vector2 dirVec = (jupsunPos - curPos).normalized;
        startPos = new Vector2(curPos.x - 8, curPos.y); // ���� ��ġ(smoothmove���� �����̵��Ǿ����� ����Ͽ�, -8�� �Ͽ� ��������)
        StartCoroutine(LineExpand(dirVec));
    }

}
